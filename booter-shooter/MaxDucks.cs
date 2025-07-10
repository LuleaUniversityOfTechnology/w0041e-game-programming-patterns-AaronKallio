using Godot;
using System;

public partial class MaxDucks : OptionButton
{
    
    
    public override void _PhysicsProcess(double delta){
       GameManager.gameManagerSingleton.Instance.runs = Selected+1;
    }
}
