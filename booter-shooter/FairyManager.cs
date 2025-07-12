using Godot;
using System;
using System.Collections.Generic;

public partial class FairyManager : Node
{
  public List<fairy_script> fairyPool = new List<fairy_script>();
  PackedScene fairyScene = GD.Load<PackedScene>("res://fairy_scene.tscn");

  public override void _Ready()
  {
    for (int i = 0; i < GameManager.gameManagerSingleton.Instance.runs; i++)
    {
      fairy_script fairy = fairyScene.Instantiate<fairy_script>();
      AddChild(fairy);
      fairyPool.Add(fairy);

    }
    //fairyPool[0].Position = new Vector3(5,5,-10);
    fairyPool[0].currentState = fairy_script.State.move;
    
  }
}

