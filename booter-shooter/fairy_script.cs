using Godot;
using System;

public partial class fairy_script : Node3D
{


    //[Signal]
    // public delegate void ResetEventHandler();
    public enum State
    {
        spawn,
        move,
        reset,
        idle
    }
    public int fairyNum; 
    public State currentState;


   // [Export]
   // Node3D fairy;

    //[Export]
    //RayCast3D raycast;

 //   [Export]
   // Node3D body;

    [Export]
    Curve fairyCurve1;

    [Export]
    Curve fairyCurve2;

    [Export]
    GpuParticles3D blood;
    
    //[Export]
    //Node3D fairyBox;

   // [Export]
    // Node3D collision;

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
    public bool hit = false;

    Vector3 clickTo;

    private Camera3D _camera;
    private RayCast3D rayCast;

    /*
        public override void _Ready()
        {
            rayCast = GetTree().Root.FindChild("RayCast3D", true, false) as RayCast3D;
            rayCast.TargetPosition = new Vector3(0, 10, 0); // Cast 10 units downward
            //fairyReady();
            currentState = State.move;
            _camera = GetNode<Camera3D>("game/Camera3D");  // Adjust path as needed
            Camera3d.RaycastHitEvent += OnRaycastHit;
        }

        private void OnRaycastHit(Vector3 position)
        {
            //GD.Print($"Raycast hit at: {position}");
            clickTo = position;

        }
        public void fairyXsetter()
        {
            xFlipper = GD.RandRange(0, 1);
            if (xFlipper == 0)
            {
                x = -10;
            }
            else
            {
                x = 10;
            }
        }



        public void fairyYsetter()
        {
            x = GD.RandRange(-5, 5);
        }

        public void fairyReady()
        {
            z = GD.RandRange(-5, -20);
            if (sideSpawn == 1)
            {
                fairyXsetter();
            }
            else
            {
                y = 0;
                fairyYsetter();
            }


        }


        public void fairyMoverX(double delta)
        {
            timer += delta / 5;
            if (timer > 1)
            {
                timer = 0;
            }
            if (graphSelector == 0)
            {
                y = 3 + fairyCurve1.Sample((float)timer);
            }
            else
            {
                y = 3 + fairyCurve2.Sample((float)timer);
            }

            if (xFlipper == 0)
            {
                x += 0.04f * speedMaker;
            }
            else
            {
                x -= 0.04f * speedMaker;
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
            timer += delta / 10;
            if (timer > 1)
            {
                timer = 0;
            }
            if (graphSelector == 0)
            {
                x = x + (fairyCurve1.Sample((float)timer) / 10);
            }
            else
            {
                x = x + (fairyCurve2.Sample((float)timer) / 10);
            }

            y += 0.04f;
        }

        public void fairyRaytrace()
        {
            Camera3d.RaycastHitEvent += OnRaycastHit;
            rayCast.TargetPosition = clickTo;

            //GD.Print(rayCast.TargetPosition);
            //if(rayCast.IsColliding()){


            var collider = rayCast.GetCollider();



            if (collider == collision)
            {
                hit = true;
                bloodY = y;
                score++;
                totalScore++;
                //GD.Print(bloodY);
                blood.Position = new Vector3(0, bloodY + 3, 0);
                blood.Emitting = true;
            }
            if (hit == true)
            {
                currentState = State.reset;
                Vector3 movement = new Vector3(x, -3, z);
                fairy.SetPosition(movement);
                body.SetPosition(movement);
            }

        }

        bool fairyOutOfBounds()
        {
            if (y > 20 || x > 30 || x < -30)
            {
                return true;
            }
            return false;
        }

        void handleFairy(double delta)
        {


            switch (currentState)
            {
                case State.spawn:
                    z = GD.RandRange(-5, -20);
                    fairyReady();
                    break;

                case State.move:
                    if (sideSpawn == 1)
                    {
                        fairyMoverX(delta);
                    }
                    else
                    {
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


        void fairyReset()
        {
            if (fairyOutOfBounds())
            {
                Vector3 movement = new Vector3(0, -3, 0);
                fairy.SetPosition(movement);
                body.SetPosition(movement);


            }


            currentState = State.reset;

        }

        public override void _PhysicsProcess(double delta)
        {

            fairyRaytrace();
            handleFairy(delta);
            fairyReset();
            if (Input.IsActionPressed("exit"))
            {


            }
        }
    */
    public override void _Ready()
    {
        //Position = new Vector3(0, 5, -5);
        // rayCast = GetTree().Root.FindChild("RayCast3D", true, false) as RayCast3D;
        // rayCast.TargetPosition = new Vector3(0, 10, 0); // Cast 10 units downward

        //  Camera3d.RaycastHitEvent += OnRaycastHit;
        //var fairyHit = GetNode<FairyBox>("fairy_scene/FairyBox");
        // fairyBox.Connect(FairyBox.SignalName.Hit, new Callable(this, nameof(whenHit)));
        var manager = GetNode<FairyManager>("/root/LevelGame");
        manager.Connect(FairyManager.SignalName.RunStart, new Callable(this, nameof(Start)));
        currentState = State.idle;
        
    }


    public void Hit()
    {
        currentState = State.idle;
        GD.Print("brudda");
        
        //GetTree().Root.PrintTreePretty();
        FairyManager.FairyManagerSingleton.Instance.fairysReset += 1;
}


    public void Start()
    {
        if (fairyNum <= FairyManager.FairyManagerSingleton.Instance.currentRuns)
        {
            currentState = State.reset;
        }
        //GetTree().Root.PrintTreePretty();
}

    private void PoolPlacer()
    {
        Position = new Vector3(0, 0,100);
    }
    public void fairyXsetter()
        {
            xFlipper = GD.RandRange(0, 1);
            if (xFlipper == 0)
            {
                x = -10;
            }
            else
            {
                x = 10;
            }
        }



        public void fairyYsetter()
        {
            x = GD.RandRange(-5, 5);
        }
        public void FairyReady()
        {
            z = GD.RandRange(-5, -20);
            if (sideSpawn == 1)
            {
                fairyXsetter();
            }
            else
            {
                y = 0;
                fairyYsetter();
            }

        currentState = State.move;
        }

    public void FairyMove(double delta)
    {
        if (sideSpawn == 1)
        {
            fairyMoverX(delta);
        }
        else
        {
            fairyMoverY(delta);
        }
        Position = new Vector3(x,y,z);
    }

        public void fairyMoverX(double delta)
        {
            timer += delta / 5;
            if (timer > 1)
            {
                timer = 0;
            }
            if (graphSelector == 0)
            {
                y = 3 + fairyCurve1.Sample((float)timer);
            }
            else
            {
                y = 3 + fairyCurve2.Sample((float)timer);
            }

            if (xFlipper == 0)
            {
                x += 0.04f * speedMaker;
            }
            else
            {
                x -= 0.04f * speedMaker;
            }

        }
        public void fairyMoverY(double delta)
        {
            timer += delta / 10;
            if (timer > 1)
            {
                timer = 0;
            }
            if (graphSelector == 0)
            {
                x = x + (fairyCurve1.Sample((float)timer) / 10);
            }
            else
            {
                x = x + (fairyCurve2.Sample((float)timer) / 10);
            }

            y += 0.04f;
        }


        void fairyOutOfBounds()
        {
        //GD.Print(x, " ", y, " ", z);
        if (y > 20 || x > 30 || x < -30)
        {
            //GD.Print("penis");
            currentState = State.idle;
            FairyManager.FairyManagerSingleton.Instance.fairysReset += 1;
        }
           
        }

        
    public void StateExecute(double delta)
    {
        switch (currentState)
        {
            case State.idle:
                PoolPlacer();
                break;

            case State.move:
                FairyMove(delta);
                fairyOutOfBounds();
                break;

            case State.reset:
                FairyReady();
                break;
            case State.spawn:
                break;
        }

    }
    public override void _PhysicsProcess(double delta)
    {
        //GD.Print(currentState);
        //GD.Print("x = ", x , " y =", y, " z= ",z);
        //GD.Print(FairyManager.FairyManagerSingleton.Instance.fairysReset);
        GD.Print(fairyNum, " ", currentState);
        StateExecute(delta);
        
        
    }
}
