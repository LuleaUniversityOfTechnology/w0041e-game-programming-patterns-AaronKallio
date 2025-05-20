
using Godot;
using System;


public partial class fairyNode : Node3D
{

[Export]
Node3D fairy;

//[Export]
//RayCast3D raycast;

[Export]
Node3D body;

[Export]
Curve fairyCurve1;

[Export]
Curve fairyCurve2;

[Export]
GpuParticles3D blood;

[Export]
Node3D collision;

Curve currentCurve;
float count = 0;
float y = 3;
double timer = 0;
int graphSelector = GD.RandRange(0, 1);
float z;
float x;
float bloodY;
    static public int score = 0;
static public int totalScore = 0;
int xFlipper;
float speedMaker = (float)GD.RandRange(0.5, 3.0);
int sideSpawn = GD.RandRange(0, 1);
bool hit = false;

Vector3 clickTo;

private Camera3D _camera;
private RayCast3D rayCast;

float fairyCountMax = StartButton.fairyCount;




enum State
{
    spawn, 
    move,
    reset
}

State currentState;
    public override void _Ready()
    {   
        //var emitter = GetNode<Camera3d>("/root/Camera3d");
        //emitter.Connect("RaycastSignalEventHandler", new Callable(this, nameof(OnMySignalReceived)));
        //var emitter2 = GetNode<Camera3d>("/root/Camera3d");
        //emitter2.Connect("numberEventHandler", new Callable(this, nameof(OnMySignalReceived2)));


        //rayCast = GetNode<RayCast3D>("game/Camera3D/RayCast3D");
        rayCast = GetTree().Root.FindChild("RayCast3D", true, false) as RayCast3D;
        rayCast.TargetPosition = new Vector3(0, 10, 0); // Cast 10 units downward
        fairyReady();
        currentState = State.move;
        _camera = GetNode<Camera3D>("game/Camera3D");  // Adjust path as needed
        Camera3d.RaycastHitEvent += OnRaycastHit;
    }

    /*
    public void OnMySignalReceived(Vector3 clickTo)
    {
        GD.Print(clickTo);

    }

    public float OnMySignalReceived2(float number)
    {
        return number;
    }
*/
    private void OnRaycastHit(Vector3 position)
    {
        //GD.Print($"Raycast hit at: {position}");
        clickTo = position;

    }

     public void fairyXsetter()
    {
       xFlipper = GD.RandRange(0, 1);
       if (xFlipper == 0){
            x = -10;
        }
        else{
            x = 10;
        }
    }



    public void fairyYsetter()
    {
      x = GD.RandRange(-5, 5);
    }

    public void fairyReady(){
        z = GD.RandRange(-5, -20);
        if(sideSpawn== 1){
            fairyXsetter();
        }
        else{
            y = 0;
            fairyYsetter();
        }
         if(Game.fairyHitCount == 0){
            
            currentState = State.move;

        }
        
    }


    public void fairyMoverX(double delta)
    {
        timer+=delta/5;
       if (timer>1){
        timer = 0;
       }
       if(graphSelector == 0){    
         y =  3 + fairyCurve1.Sample((float)timer);
        }
        else{
         y =  3 + fairyCurve2.Sample((float)timer);
        }

       if (xFlipper == 0){
            x += 0.04f*speedMaker;
        }
        else{
            x -= 0.04f*speedMaker;
        }

    }

    public void resetZone(double delta)
    {
        //Vector3 movement = new Vector3(1, 5, 1);
        hit = false;
        currentState = State.spawn;

        
    }

    public void fairyMoverY(double delta)
    {
       timer+=delta/10;
       if (timer>1){
        timer = 0;
       }
       if(graphSelector == 0){
         x =  x + (fairyCurve1.Sample((float)timer)/10);
        }
        else{
         x =  x + (fairyCurve2.Sample((float)timer)/10);
        }

         y += 0.04f;
    }

    public void fairyRaytrace(){
        Camera3d.RaycastHitEvent += OnRaycastHit;
        rayCast.TargetPosition = clickTo;
       
         //GD.Print(rayCast.TargetPosition);
        //if(rayCast.IsColliding()){


        var collider = rayCast.GetCollider();
       
        

        if(collider == collision){
            hit = true;
            Game.fairyHitCount++;
            bloodY = y;
            score++;
            totalScore++;
            //GD.Print(bloodY);
            blood.Position = new Vector3(0, bloodY+3, 0);
            blood.Emitting = true;
        }
        if(hit==true){
            currentState = State.reset;
            Vector3 movement = new Vector3(x, -3, z);
            fairy.SetPosition(movement);
            body.SetPosition(movement);
        }

    }

    bool fairyOutOfBounds(){
        if(y > 20 || x > 30 || x < -30){
            return true;
        }
        return false;
    }

    void handleFairy(double delta){


        switch (currentState){
        case State.spawn:
                z = GD.RandRange(-5, -20);
                fairyReady();
            break;

        case State.move:
            if(sideSpawn==1){
            fairyMoverX(delta);
        }
        else{
            fairyMoverY(delta);
        }
        
       Vector3 movement = new Vector3(x, y, z);
        fairy.SetPosition(movement);
        body.SetPosition(movement);
            break;
        case State.reset:
           resetZone(delta);
            break;
    }


    }


    void fairyReset(){
        if(fairyOutOfBounds()){
            Vector3 movement = new Vector3(0, -3, 0);
            fairy.SetPosition(movement);
            body.SetPosition(movement);
            Game.fairyHitCount++;
        }
        if(Game.fairyHitCount == fairyCountMax){
            Game.fairyHitCount = 0;
            score = 0;
            currentState = State.reset;

        }
    }
     public void exit()
    {
        var file = "res://data.txt";
        var file1 = FileAccess.Open(file, FileAccess.ModeFlags.ReadWrite);
        int bigScore = int.Parse(file1.GetAsText());
        if (bigScore < fairyNode.totalScore)
        {
            file1.StoreString(fairyNode.totalScore.ToString());
        }
        
   }

    public override void _PhysicsProcess(double delta)
    {
        GD.Print(Game.fairyHitCount);
        fairyRaytrace();
        handleFairy(delta);
        fairyReset();
        if (Input.IsActionPressed("exit"))
        {
            exit();
            GetTree().Quit();
    }
       
    }

    }



