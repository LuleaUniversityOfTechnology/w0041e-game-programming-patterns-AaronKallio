using Godot;
using System;
using System.Threading;

public partial class LabelScript : Label
{
    public override void _PhysicsProcess(double delta)
    {
        Text = "Current hits in run = " + fairyNode.score + "    Total score is = " + fairyNode.totalScore;
        


    }

   
}
