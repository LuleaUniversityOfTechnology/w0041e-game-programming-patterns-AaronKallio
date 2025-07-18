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

    
}
