using Godot;
using System;

public class Game : Node2D
{
    Level level;
    Player player;
    Constructor constructor;

    private int currentlevel = 0;

    String[] levels = 
    {
        "res://Scenes/Levels/Level3.tscn",
        "res://Scenes/Levels/Level2.tscn",
        "res://Scenes/Levels/Level3.tscn",
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
        constructor = (Constructor)GetNode("Constructor");
        constructor.player = player;
        player.GlobalPosition = level.entrance.spawnPoint.GlobalPosition;
        player.Connect("PlayerDead", this, nameof(_Reset_Level));
        level.exit.Connect("PlayerExit", this, nameof(_End_Reached));
    }

    public void _Reset_Level()
    {
        loadLevel(levels[0]);
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
