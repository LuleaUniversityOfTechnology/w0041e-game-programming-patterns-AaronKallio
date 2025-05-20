using Godot;
using System;

public partial class StartButton : Button

{
    public static float fairyCount = 0;
    [Export]
    OptionButton fairies;
  
    public override void _Ready()
    {
        // Connect the button pressed signal to the handler
        this.Pressed += _on_StartButton_pressed;

    }

    // This function will be called when the button is pressed
    private void _on_StartButton_pressed()
    {
   
        int maxFairies = fairies.GetSelectedId();
        fairyCount = maxFairies;
        var global = GetNode<BigData>("/root/BigData");
        global.GotoScene("res://game.tscn");
           
    }
}