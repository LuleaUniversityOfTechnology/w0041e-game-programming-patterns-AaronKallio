using Godot;
using System;

public partial class fairy_script : Node3D
{
    public enum State
    {
        move,
        reset,
        idle
    }
    public int fairyNum; 
    public State currentState;

    [Export]
    Curve fairyCurve1;

    [Export]
    Curve fairyCurve2;

    //[Export]
    //GpuParticles3D blood;
   

    
    float y = 3;
    double timer = 0;
    int graphSelector = GD.RandRange(0, 1);
    float z;
    float x;
    int xFlipper;
    float speedMaker = (float)GD.RandRange(3.0, 6.0);
    int sideSpawn = GD.RandRange(0, 1);
    PackedScene blood;

    public override void _Ready()
    {
        var manager = GetNode<FairyManager>("/root/LevelGame");
        manager.Connect(FairyManager.SignalName.RunStart, new Callable(this, nameof(Start)));
        currentState = State.idle;
        blood = GD.Load<PackedScene>("res://blood.tscn");

    }
    public void Hit()
    {
        var bloodShow = blood.Instantiate<GpuParticles3D>();
        bloodShow.GlobalTransform = GlobalTransform;
        GetTree().CurrentScene.AddChild(bloodShow);
        bloodShow.Emitting = true;
        currentState = State.idle;
        FairyManager.FairyManagerSingleton.Instance.fairysReset += 1;
        FairyManager.FairyManagerSingleton.Instance.fairyScore += 1;
        FairyManager.FairyManagerSingleton.Instance.fairysHitInRun += 1;
}
    public void Start()
    {
        if (fairyNum <= FairyManager.FairyManagerSingleton.Instance.currentRuns)
        {
            currentState = State.reset;
        }
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

            y += 0.04f* (speedMaker/2);
        }

        void fairyOutOfBounds()
        {
        if (y > 20 || x > 30 || x < -30)
        {
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
        }

    }
    public override void _PhysicsProcess(double delta)
    {
        StateExecute(delta);
    }
}
