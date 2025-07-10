using Godot;
using System;

public partial class StartButton : Button

{
    /*
    public static float fairyCount = 0;
    [Export]
    OptionButton fairies;
   */
    public override void _Ready()
    {
        // Connect the button pressed signal to the handler
        this.Pressed += _on_StartButton_pressed;

    }

    // This function will be called when the button is pressed
    private void _on_StartButton_pressed()
    {
        GameManager.gameManagerSingleton.Instance.currentState = GameManager.gameManagerSingleton.State.game;
           
    }
   
}



    /*
    public override void _PhysicsProcess(double delta)
    {
        Text = "Current hits in run = " + fairyNode.score + "    Total score is = " + fairyNode.totalScore;
        


    }
*/
   


