
using Godot;
using System;


public partial class fairyNode : Node3D
{

[Export]
Node3D fairy;

[Export]
RayCast3D rayCast;

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
int z = GD.RandRange(-5, -20);
float x;
float bloodY; 

int xFlipper;
float speedMaker = (float)GD.RandRange(0.5, 3.0);
int sideSpawn = GD.RandRange(0, 1);
bool hit = false;

    public override void _Ready()
    {
        rayCast.TargetPosition = new Vector3(0, 10, 0); // Cast 10 units downward
        fairyReady();
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
        if(sideSpawn== 1){
            fairyXsetter();
        }
        else{
            fairyYsetter();
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
            x += 0.06f*speedMaker;
        }
        else{
            x -= 0.06f*speedMaker;
        }

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

         y += 0.06f;
    }

    public void fairyDeath(double delta)
    {
       if(hit == false){

        if(sideSpawn==1){
            fairyMoverX(delta);
        }
        else{
            fairyMoverY(delta);
        }
        
       Vector3 movement = new Vector3(x, y, z);
        fairy.SetPosition(movement);
        body.SetPosition(movement);
        }
        rayCast.TargetPosition = Camera3d.clickTo;
         //GD.Print(rayCast.TargetPosition);
        //if(rayCast.IsColliding()){
        var collider = rayCast.GetCollider();
        GD.Print("--------");
        GD.Print(collider);
        GD.Print(collision);
        GD.Print("--------");

        if(collider == collision){
            hit = true;
            bloodY = y;
            GD.Print("e");
            //GD.Print(bloodY);
          blood.Position = new Vector3(0, bloodY+3, 0);
            blood.Emitting = true;
        }
        if(hit==true){
            Vector3 movement = new Vector3(x, -3, z);
            fairy.SetPosition(movement);
            body.SetPosition(movement);
        }
    }





    public override void _PhysicsProcess(double delta){

        fairyDeath(delta);
        
     
    }

    }



