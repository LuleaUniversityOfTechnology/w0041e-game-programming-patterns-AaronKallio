using Godot;
using System;

public partial class Game : Node
{
    
    [Export]
    public PackedScene bird_manager { get; set; }

   
    public override void _Ready(){
        //fairyNode fairy1 = bird_manager.fairyReady<fairyNode>();
        //addChild(fairy1);
    }


    
}
