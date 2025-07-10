using Godot;
using System;
using System.Collections.Generic;

public partial class FairyManager : Node
{
    public List<Node3D> fairyPool = new List<Node3D>();
   PackedScene fairyScene = GD.Load<PackedScene>("res://fairy_scene.tscn");
     
     public override void _Ready(){
     for (int i = 0; i < GameManager.gameManagerSingleton.Instance.runs; i++){
            Node3D fairy = fairyScene.Instantiate<Node3D>();
            AddChild(fairy);
            fairyPool.Add(fairy);
        }
     }
}
