using Godot;
using System;

public class Game : Node2D
{
    private Level level;
    private Player player;
    private GameManager gameManager;
    private Constructor constructor;

    public override void _Ready()
    {
        level = (Level)GetNode("Level");
        player = (Player)GetNode("Player");
        gameManager = (GameManager)GetNode("GameManager");
        constructor = (Constructor)GetNode("Constructor");
        player.GlobalPosition = level.entrance.spawnPoint.GlobalPosition;
        player.Connect("PlayerDead", this, nameof(_Reset_Level));
        level.exit.Connect("PlayerExit", this, nameof(_End_Reached));
    }

    public void _Reset_Level()
    {
        gameManager.loadLevel(gameManager.currentlevel);
    }

    public void _End_Reached()
    {
        gameManager.currentlevel++;
        gameManager.Save();
        gameManager.loadLevel(gameManager.currentlevel);
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

    public void _on_GooSprayer_SpawnGoo(Vector2 pos)
    {
        constructor.SpawnGoo(pos);
    }
}
