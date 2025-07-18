using Godot;
using System;

public partial class RunLabel : Label
{
    
    public class LabelSingleton
  {
    private static LabelSingleton instance = null;
    private LabelSingleton() { }

    public static LabelSingleton Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new LabelSingleton();
        }
        return instance;
      }




    }
    public string text { get; set; } = "";
    
  }
    public override void _PhysicsProcess(double delta)
    {
        Text = LabelSingleton.Instance.text;

    }
}
