using Godot;
using System;

public partial class Game : Node
{
    
    [Export]
    public PackedScene bird_manager { get; set; }

     [Export]
    public RayCast3D raycast;
    


   
    public override void _Ready(){
        fairyNode fairy1 = bird_manager.Instantiate<fairyNode>();
        AddChild(fairy1);
        fairyNode fairy2 = bird_manager.Instantiate<fairyNode>();
        AddChild(fairy2);
        fairyNode fairy3 = bird_manager.Instantiate<fairyNode>();
        AddChild(fairy3);
        fairyNode fairy4 = bird_manager.Instantiate<fairyNode>();
        AddChild(fairy4);

    }


    
}
