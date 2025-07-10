using Godot;
using System;

public partial class LevelManager : Node
{   
    public int sceneSaver = 0;
    public void sceneSwitch(){
        if(GameManager.gameManagerSingleton.Instance.currentState == GameManager.gameManagerSingleton.State.game && sceneSaver!=1){
            GetTree().ChangeSceneToFile("res://level_game.tscn");
            sceneSaver = 1;
        }
        else if(GameManager.gameManagerSingleton.Instance.currentState == GameManager.gameManagerSingleton.State.menu && sceneSaver!=2){
            GetTree().ChangeSceneToFile("res://level_menu.tscn");
            sceneSaver = 2;
        }

    }

    public override void _PhysicsProcess(double delta){
        sceneSwitch();
    }
}
