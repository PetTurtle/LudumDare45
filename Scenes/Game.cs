using Godot;
using System;

public class Game : Node2D
{
    Level level;
    Player player;

    String[] levels = 
    {
        "res://Scenes/Game.tscn",
        "2",
        "3",
        "4",
        "5",
        "6",
        "7",
        "8"
    };
    public override void _Ready()
    {
        level = (Level)GetNode("Level");
        player = (Player)GetNode("Player");
        player.GlobalPosition = level.entrance.spawnPoint.GlobalPosition;
        level.exit.Connect("PlayerExit", this, nameof(_End_Reached));
    }

    public void _End_Reached()
    {
        loadLevel(levels[0]);
    }

    public void loadLevel(String path)
    {
        try
        {
            GetTree().ChangeScene(path);
        } catch
        {
            GD.Print("No Scene at " + path);
        }
    }
}
