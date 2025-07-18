using Godot;
using System;
using System.Transactions;

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


        public string GetScore()
    {
        
        var file = "res://data.txt";
        var file1 = FileAccess.Open(file, FileAccess.ModeFlags.Read);
        
        string line = file1.GetLine();
        //int bigScore = int.Parse(b);
        file1.Close();
        return line;

    }

    public void SetScore(int score)
    {
        
        var file = "res://data.txt";
        var file1 = FileAccess.Open(file, FileAccess.ModeFlags.Write);
         file1.StoreString(score.ToString());
        file1.Close();
       

    }
    public int runs { get; set; } = 5;

    public enum State
{
    menu, 
    game
}

 public State currentState { get; set; } = State.menu;
    }

    public override void _Ready()
    {   
        GD.Print(GameManager.gameManagerSingleton.Instance.GetScore());
    }
}
