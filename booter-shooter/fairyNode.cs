
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




float count = 0;



    public override void _Ready()
    {
        // Initialize the RayCast node
       

        // Set the raycast to start from the object's position (or any other starting point)
        
        rayCast.TargetPosition = new Vector3(0, -10, 0); // Cast 10 units downward
    }
//fairy.GlobalPosition = Vector3.Zero;
    public override void _PhysicsProcess(double delta){

        
       

        rayCast.TargetPosition = Camera3d.clickTo;
        if(rayCast.IsColliding()){
            GD.Print("testicle");
        }
      // GD.Print(Camera3d.clickX);
        //GD.Print(Camera3d.to);
        //fairy.GlobalPosition.X -= 1;
        //fairyVelocity = new Vector3{1,0,0};
         //fairy.Translate(fairyVelocity * delta);
        //Vector3 movement = new Vector3(1 * 5 * (float)delta + count, 0, 0);

        
        //var worldspace = GetWorld3D().DirectSpaceState;
        //var query = PhysicsRayQueryParameters3D.create(Camera3d.clickFrom, Camera3d.clickTo);
        //var result = worldspace.IntersectRay(query);
        Vector3 movement = new Vector3(count+8, 3, -14);
        count -= 0.02f;
        fairy.SetPosition(movement);
        body.SetPosition(movement);
        //GD.Print(Camera3d.clickTo);
        //GD.Print(result);
       

        


        //fairy.set_translation(fairy.get_translation() + movement);


        /*
        var clickVector = new Vector3(camera.clickX,camera.clickY,camera.clickZ);
        if(clickVector.GetCollider()!=0){
            
        }
        */
    }

    }



