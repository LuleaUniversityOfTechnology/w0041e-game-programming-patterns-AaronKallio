using Godot;
using System;
using System.Collections.Generic;

public partial class FairyManager : Node3D
{
    [Export] PackedScene FairyScene; // Assign your Fairy scene in the Inspector
    [Export] int maxFairies = 5; // Number of fairies to spawn
    [Export] float spawnInterval = 2.0f; // Time between spawns

    private Timer spawnTimer;
    private List<Node3D> fairies = new List<Node3D>();

    public override void _Ready()
    {
        spawnTimer = new Timer();
        AddChild(spawnTimer);
        spawnTimer.WaitTime = spawnInterval;
        spawnTimer.OneShot = false;
        spawnTimer.Timeout += SpawnFairy;
        spawnTimer.Start();

        // Spawn initial fairies
        for (int i = 0; i < maxFairies; i++)
        {
            SpawnFairy();
        }
    }

    private void SpawnFairy()
    {
        if (FairyScene == null) 
        {
            GD.PrintErr("FairyScene not assigned!");
            return;
        }

        if (fairies.Count >= maxFairies) return; // Limit the number of fairies

        Node3D fairyInstance = (Node3D)FairyScene.Instantiate();
        AddChild(fairyInstance);
        fairies.Add(fairyInstance);

        // Random spawn position
        //float x = (float)GD.RandRange(-10, 10);
        //float y = (float)GD.RandRange(3, 6);
        //float z = (float)GD.RandRange(-20, -5);
        //fairyInstance.Position = new Vector3(x, y, z);

        GD.Print("Spawned Fairy at: ", fairyInstance.Position);
    }

    public void RemoveFairy(Node3D fairy)
    {
        if (fairies.Contains(fairy))
        {
            fairies.Remove(fairy);
            fairy.QueueFree();
        }
    }
}
