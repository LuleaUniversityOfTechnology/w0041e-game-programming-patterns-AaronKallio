using Godot;
using Godot.Collections;
using System;

public partial class Camera3d : Camera3D
{

    float RayLength = 500.0f;
    
    //Vector2 centre;
    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("shoot"))
        {
            GetCameraCollision();
        }
    }

    public void GetCameraCollision()
    {

        //var centre = GetViewport().GetVisibleRect().Size / 2;
        var centre = GetViewport().GetMousePosition();
        var rayOrigin = ProjectRayOrigin(centre) * 0.1f;
        var rayEnd = rayOrigin + ProjectRayNormal(centre) * RayLength;
        var newIntersection = PhysicsRayQueryParameters3D.Create(rayOrigin, rayEnd);
        var intersection = GetWorld3D().DirectSpaceState.IntersectRay(newIntersection);


        RayCast3D raycast = new RayCast3D();
        AddChild(raycast);
        raycast.GlobalTransform = new Transform3D(Basis.Identity, rayOrigin);

        // TargetPosition is local to the RayCast3D, so convert target to local space
        raycast.TargetPosition = raycast.ToLocal(rayEnd);

        // Enable the RayCast3D to make it active
        raycast.Enabled = true;

        // Add it to the scene tree so it can work properly
       // AddChild(raycast);

        // Force it to update the collision info immediately
        raycast.ForceRaycastUpdate();



        //GD.Print(intersection);
        if (intersection.Count > 0 && intersection.ContainsKey("collider"))
        {
            var collision = raycast.GetCollider();
            var collider = intersection["collider"] as Object;
            if (collision.HasMethod("Hit"))
            {
                collision.Call("Hit");
                GD.Print(collider);

            }
        }
        else
        {
            GD.Print("blue balls");

        }
        raycast.QueueFree();
    }

    /*
    [Export]
    Camera3D camera3D;
   
    public static event Action<Vector3> RaycastHitEvent;

    
    
   
    public static float clickX = 0;
    public static float clickY = 0;
    public static float clickZ = 0;
    public static float timer = 0;


    public static Vector3 clickTo;
    public static Vector3 clickFrom;

     //[Signal] public delegate void RaycastSignal(Vector3 clickTo);
    [Signal] 
    public delegate void RaycastSignalEventHandler(Vector3 clickTo);

    [Signal] 
    public delegate void numberEventHandler(float number);
    private const float RayLength = 500.0f;

public override void _Ready()
{

}
public override void _Input(InputEvent @event)
{
    
    clickTo = new Vector3(0,0,0);
    clickFrom = new Vector3(0,0,0);
    timer+=0.1f;
        if (@event is InputEventMouseButton eventMouseButton && eventMouseButton.Pressed && eventMouseButton.ButtonIndex == MouseButton.Left)//&&timer>1)
                                                                                                                                             //if (@event is InputEventMouseButton eventMouseButton && eventMouseButton.Pressed &&timer>1)
        {
            
            //var camera3D = GetNode<Camera3D>("Camera3D");
            var from = camera3D.ProjectRayOrigin(eventMouseButton.Position);
             GD.Print(from);
              GD.Print(eventMouseButton.Position);
            var to = from + camera3D.ProjectRayNormal(eventMouseButton.Position) * RayLength;
            //GD.Print(to);
            //DebugDraw3D.DrawArrow(from, to);
            clickX = to.X;
            clickY = to.Y;
            clickZ = to.Z;
            clickTo = to;
            clickFrom = from;
            timer = 0;
            EmitSignal(nameof(RaycastSignalEventHandler), clickTo);
            EmitSignal(nameof(numberEventHandler), 5);
            RaycastHitEvent?.Invoke(clickTo);
            //GD.Print(clickTo);
        

       
        }



}
*/
}
