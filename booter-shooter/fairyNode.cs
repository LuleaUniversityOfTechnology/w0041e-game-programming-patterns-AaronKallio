
using Godot;
using System;


public partial class fairyNode : Node3D
{

[Export]
Node3D fairy;

[Export]
RayCast3D camera;


float count = 0;

//fairy.GlobalPosition = Vector3.Zero;
    public override void _PhysicsProcess(double delta){
        //fairy.GlobalPosition.X -= 1;
        //fairyVelocity = new Vector3{1,0,0};
         //fairy.Translate(fairyVelocity * delta);
        //Vector3 movement = new Vector3(1 * 5 * (float)delta + count, 0, 0);
        Vector3 movement = new Vector3(count+8, 3, -14);
        count -= 0.08f;
        fairy.SetPosition(movement);
        //fairy.set_translation(fairy.get_translation() + movement);

    }


}


