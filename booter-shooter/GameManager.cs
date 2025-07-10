using Godot;
using System;

public partial class GameManager : Node
{
    public class gameManagerSingleton{
        private static gameManagerSingleton instance = null;
        private gameManagerSingleton() { }

        public static gameManagerSingleton Instance{
            get{
                if(instance == null){
                    instance = new gameManagerSingleton();
                }
                return instance;
            }
        }

        public string getScore()
    {
        
        var file = "res://data.txt";
        var file1 = FileAccess.Open(file, FileAccess.ModeFlags.Read);
        
        string line = file1.GetLine();
        //int bigScore = int.Parse(b);
        file1.Close();
        return line;

    }

    public void setScore(int score)
    {
        
        var file = "res://data.txt";
        var file1 = FileAccess.Open(file, FileAccess.ModeFlags.Write);
         file1.StoreString(score.ToString());
        file1.Close();
       

    }

    }

    public override void _PhysicsProcess(double delta)
    {
        GD.Print(GameManager.gameManagerSingleton.Instance.getScore());
        GameManager.gameManagerSingleton.Instance.setScore(999);
    }
}
