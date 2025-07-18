using Godot;
using System;

public partial class LabelMenu : Label
{
    
    public override void _Ready()
    {
        var file = "res://data.txt";
        using var file1 = FileAccess.Open(file, FileAccess.ModeFlags.Read);
        Text = "highscore = " + file1.GetLine();
        if (file1 == null)
        {
            Text = "bruh";
        }
        
        file1.Close();
    }

    public override void _PhysicsProcess(double delta)
    {
      
       
    }
   
}
