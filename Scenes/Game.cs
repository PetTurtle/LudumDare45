using Godot;
using System;

public class Game : Node2D
{
    private Level level;
    private Player player;
    private int currentlevel = 0;
    private int maxLevel = 0;

    String menu = "res://Scenes/Levels/Menu.tscn";

    String[] levels = 
    {
        "res://Scenes/Levels/Level1.tscn",
        "res://Scenes/Levels/Level2.tscn",
        "res://Scenes/Levels/Level3.tscn",
        "res://Scenes/Levels/Level4.tscn",
        "res://Scenes/Levels/Level5.tscn",
        "res://Scenes/Levels/Level6.tscn",
        "res://Scenes/Levels/Level7.tscn",
        "res://Scenes/Levels/Level8.tscn",
        "res://Scenes/Levels/Level9.tscn"
    };
    public override void _Ready()
    {
        level = (Level)GetNode("Level");
        player = (Player)GetNode("Player");
        player.GlobalPosition = level.entrance.spawnPoint.GlobalPosition;
        player.Connect("PlayerDead", this, nameof(_Reset_Level));
        level.exit.Connect("PlayerExit", this, nameof(_End_Reached));
    }

    public void _Reset_Level()
    {
        loadLevel(levels[currentlevel]);
    }

    public void _End_Reached()
    {
        currentlevel++;
        loadLevel(levels[currentlevel]);
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
