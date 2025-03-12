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

        if(StartButton.fairyCount>=5){
            fairyNode fairy2 = bird_manager.Instantiate<fairyNode>();
            AddChild(fairy2);
        }
        if(StartButton.fairyCount>=4){
            fairyNode fairy3 = bird_manager.Instantiate<fairyNode>();
            AddChild(fairy3);
        }
        if(StartButton.fairyCount>=3){
            fairyNode fairy4 = bird_manager.Instantiate<fairyNode>();
            AddChild(fairy4);
        }
        if(StartButton.fairyCount>=2){
            fairyNode fairy5 = bird_manager.Instantiate<fairyNode>();
            AddChild(fairy5);
        }
        
        
        
        GD.Print(StartButton.fairyCount);
        
        
    }


    
}
