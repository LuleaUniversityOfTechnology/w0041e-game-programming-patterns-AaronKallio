using Godot;
using System;
using System.Collections.Generic;

public partial class FairyManager : Node
{
  [Signal]
  public delegate void RunStartEventHandler();
  public class FairyManagerSingleton
  {
    private static FairyManagerSingleton instance = null;
    private FairyManagerSingleton() { }

    public static FairyManagerSingleton Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new FairyManagerSingleton();
        }
        return instance;
      }




    }
    public int fairysReset { get; set; } = 0;
    public int currentRuns { get; set; } = 1;
  }


  public int runs;
  //public int currentRuns = 1;

  public int currentFairys;

  public bool runReset = true;
  public List<fairy_script> fairyPool = new List<fairy_script>();
  PackedScene fairyScene = GD.Load<PackedScene>("res://fairy_scene.tscn");

  public override void _Ready()
  {
    runs = GameManager.gameManagerSingleton.Instance.runs;
    for (int i = 0; i < GameManager.gameManagerSingleton.Instance.runs; i++)
    {
      fairy_script fairy = fairyScene.Instantiate<fairy_script>();
      AddChild(fairy);
      fairyPool.Add(fairy);
      GD.Print(runs);
      fairyPool[i].fairyNum = i + 1;
      FairyWave();


      //var fairyNode = GetNode<fairy_script>("res://fairy_scene/FairyScene"); // Adjust path as needed

      //fairyNode.Connect(fairy_script.SignalName.Reset, new Callable(this, nameof(ResetCount)));

    }
    //fairyPool[0].Position = new Vector3(5,5,-10);
    // fairyPool[0].currentState = fairy_script.State.move;

  }

  public void FairyWave()
  {
    if (runReset == false)
    {
      EmitSignal(SignalName.RunStart);
      runReset = true;
    }
    //EmitSignal(SignalName.RunStart);

  }

  public void ResetCount()
  {
    if (FairyManagerSingleton.Instance.fairysReset == FairyManagerSingleton.Instance.currentRuns)
    {
      FairyManagerSingleton.Instance.fairysReset = 0;
      runReset = false;
      if (currentFairys < GameManager.gameManagerSingleton.Instance.runs)
      {
        currentFairys++;
      }
    }
  }

  public override void _PhysicsProcess(double delta)
  {
    FairyWave();
    ResetCount();
  }
}
