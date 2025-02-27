using Godot;
using System;

public partial class Camera3d : Camera3D
{
    [Export]
    Camera3D camera3D;

    
    private int _myVariable = 0;

    
    
   
    public static float clickX = 0;
    public static float clickY = 0;
    public static float clickZ = 0;

    public static Vector3 clickTo;
    public static Vector3 clickFrom;



    private const float RayLength = 500.0f;

public override void _Input(InputEvent @event)
{
    clickTo = new Vector3(0,0,0);
    clickFrom = new Vector3(0,0,0);
    if (@event is InputEventMouseButton eventMouseButton && eventMouseButton.Pressed && eventMouseButton.ButtonIndex == MouseButton.Left)
    {
        //var camera3D = GetNode<Camera3D>("Camera3D");
        var from = camera3D.ProjectRayOrigin(eventMouseButton.Position);
        var to = from + camera3D.ProjectRayNormal(eventMouseButton.Position) * RayLength;
        //GD.Print(to);
        //DebugDraw3D.DrawArrow(from, to);
        clickX = to.X;
        clickY = to.Y;
        clickZ = to.Z;
        clickTo = to;
        clickFrom = from;

       
        }
    }
    

}
