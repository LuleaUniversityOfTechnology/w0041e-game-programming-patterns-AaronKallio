using Godot;
using System;

public partial class LabelMenu : Label
{
    public override void _Ready()
    {
        var file = "res://data.txt";
        var file1 = FileAccess.Open(file, FileAccess.ModeFlags.ReadWrite);
        Text = "highscore = " + file1.GetAsText();
        Text = "highscore = ";


    }
     
     public override void _PhysicsProcess(double delta)
    {
       var file = "res://data.txt";
        var file1 = FileAccess.Open(file, FileAccess.ModeFlags.ReadWrite);
        Text = "highscore = " + file1.GetAsText();
       
    }
}
