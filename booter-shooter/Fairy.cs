using Godot;
using System;


public partial class Fairy : MeshInstance3D
{

[Export]
Node3D fairy;

//fairy.GlobalPosition = Vector3.Zero;
Vector3 fairyVelocity = Vector3.Zero;
    public override void _PhysicsProcess(double delta){
        //fairy.GlobalPosition.X -= 1;
        fairyVelocity = new Vector3{1,0,0};
         fairy.Translate(fairyVelocity * delta);

    }


}

