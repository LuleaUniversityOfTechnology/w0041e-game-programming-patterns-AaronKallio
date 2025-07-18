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

    public int fairyScore { get; set; } = 0;

    public int fairysHitInRun { get; set; } = 0;
  }


  public int runs;
  //public int currentRuns = 1;

  

  public bool runReset = false;
  public int timer = 100;
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
      //GD.Print(GameManager.gameManagerSingleton.Instance.runs);
      fairyPool[i].fairyNum = i + 1;
      EmitSignal(SignalName.RunStart);
      //FairyWave();


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
      

      if (timer > 0)
      {
        GD.Print(timer);
        RunLabel.LabelSingleton.Instance.text = "fairys hit in run: " + FairyManagerSingleton.Instance.fairysHitInRun;
        GD.Print("yar");
        timer -= 1;
      }
      else
      {
        FairyManagerSingleton.Instance.fairysReset = 0;
      FairyManagerSingleton.Instance.currentRuns += 1;
      runReset = false;
        RunLabel.LabelSingleton.Instance.text = "";
        FairyManagerSingleton.Instance.fairysHitInRun = 0;
        timer = 100;
        FairyWave();
        BackToMenu();
      }
      
      //if (currentFairys < FairyManagerSingleton.Instance.currentRuns)
      // {
      //   currentFairys++;
      // }
    }
  }
  

  public void BackToMenu()
  {
    if (FairyManagerSingleton.Instance.currentRuns > GameManager.gameManagerSingleton.Instance.runs)
    {
      //GD.Print("poo poo pee pee");
      GameManager.gameManagerSingleton.Instance.currentState = GameManager.gameManagerSingleton.State.menu;
      FairyManagerSingleton.Instance.currentRuns = 1;
      if (int.Parse(GameManager.gameManagerSingleton.Instance.GetScore()) < FairyManagerSingleton.Instance.fairyScore)
      {
        GameManager.gameManagerSingleton.Instance.SetScore(FairyManagerSingleton.Instance.fairyScore);
      }
      
    }
  }

  public override void _PhysicsProcess(double delta)
  {

    ResetCount();

  }
}
