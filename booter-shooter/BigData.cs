using Godot;
using System;

public partial class BigData : Node
{

    public static BigData instance;

    private PackedScene _gameScene = GD.Load<PackedScene>("res://game.tscn");
    private PackedScene _menuScene = GD.Load<PackedScene>("res://menu.tscn");

    Node3D instancedGameScene; 
    Node2D instancedMenuScene; 

   
    public Node CurrentScene { get; set; }


    float toX = 0;
    int runs = 0;
    int highScore = 0;


    public override void _EnterTree()
    {
        instance = this; 
        
    }

    public void GotoScene(string path)
{
    // This function will usually be called from a signal callback,
    // or some other function from the current scene.
    // Deleting the current scene at this point is
    // a bad idea, because it may still be executing code.
    // This will result in a crash or unexpected behavior.

    // The solution is to defer the load to a later time, when
    // we can be sure that no code from the current scene is running:

    CallDeferred(MethodName.DeferredGotoScene, path);
}

public void DeferredGotoScene(string path)
{
    // It is now safe to remove the current scene.
    CurrentScene.Free();

    // Load a new scene.
    var nextScene = GD.Load<PackedScene>(path);

    // Instance the new scene.
    CurrentScene = nextScene.Instantiate();

    // Add it to the active scene, as child of root.
    GetTree().Root.AddChild(CurrentScene);

    // Optionally, to make it compatible with the SceneTree.change_scene_to_file() API.
    GetTree().CurrentScene = CurrentScene;
}


    public override void _Ready(){
        Viewport root = GetTree().Root;
        // Using a negative index counts from the end, so this gets the last child node of `root`.
        CurrentScene = root.GetChild(-1);
        var global = GetNode<BigData>("/root/BigData");
        global.GotoScene("res://menu.tscn");
        /*
        GD.Print("aasdasfasfsd");
         instancedMenuScene = (Node2D)_menuScene.Instantiate();
         GetTree().Root.AddChild(instancedMenuScene);
*/



        //instancedMenuScene = ResourceLoader.Load<PackedScene>("res://menu.tscn").Instantiate();
        //var scene = ResourceLoader.Load<PackedScene>("res://menu.tscn").Instantiate();


        //var scene = GD.Load<PackedScene>("res://menu.tscn");
        //var instance = scene.Instantiate();
        //AddChild(instance);
        
    }

    public void SceneLoad(int scene){
        if(scene == 0){
            
            instancedGameScene = (Node3D)_gameScene.Instantiate();
            //var game = ResourceLoader.Load<PackedScene>("res://game.tscn").Instantiate();
             GetTree().Root.AddChild(instancedGameScene);
             instancedMenuScene.QueueFree();
             //Instantiate the other one
        }
        else{
        }
    }


    
}
