using Godot;
using System;

public partial class StartButton : Button

{
   
    public override void _Ready()
    {
        this.Pressed += _on_StartButton_pressed;

    }

    private void _on_StartButton_pressed()
    {
        GameManager.gameManagerSingleton.Instance.currentState = GameManager.gameManagerSingleton.State.game;
           
    }
   
}

   


