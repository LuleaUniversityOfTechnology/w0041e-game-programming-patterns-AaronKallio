using Godot;
using System;

public partial class StartButton : Button
{
    // Load the scene that we want to switch to
   // private PackedScene _gameScene = GD.Load<PackedScene>("res://game.tscn");
//    private PackedScene _menuScene = GD.Load<PackedScene>("res://menu.tscn");

    public override void _Ready()
    {
        // Connect the button pressed signal to the handler
        this.Pressed += _on_StartButton_pressed;

        //BigData.instance.SceneLoad(0);
    }

    // This function will be called when the button is pressed
    private void _on_StartButton_pressed()
    {
        // Check if the scene is loaded
        //if (_gameScene != null)
        //{
        var global = GetNode<BigData>("/root/BigData");
        global.GotoScene("res://game.tscn");
            //BigData.instance.SceneLoad(0);
            // Change to the new scene using ChangeScene
           //var scene = ResourceLoader.Load<PackedScene>("res://game.tscn").Instantiate();
           //var scene2 = ResourceLoader.Load<PackedScene>("res://menu.tscn").Instantiate();
           

            //GetTree().Root.AddChild(scene);
            //Node nodeToRemove = GetNode("menu");
            //nodeToRemove.QueueFree();

             //GetTree().Root.RemoveChild(scene2);
            //GetTree().ChangeScene(scene);
            


       // }
        //else
        //{
        //    GD.Print("Error: Game scene could not be loaded.");
        //}
    }
}