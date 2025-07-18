using Godot;
using System;

public partial class DisplayScore : Label
{
    public override void _Ready()
    {
        Text = "0";
    }
    public override void _PhysicsProcess(double delta)
    {
        Text = FairyManager.FairyManagerSingleton.Instance.fairyScore.ToString();
    }
}
