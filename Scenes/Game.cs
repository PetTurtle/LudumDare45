using Godot;
using System;

public class Game : Node2D
{
    private Level level;
    private Player player;
    private GameManager gameManager;
    private Constructor constructor;
    private GameCanvas canvas;

    public override void _Ready()
    {
        level = (Level)GetNode("Level");
        player = (Player)GetNode("Player");
        gameManager = (GameManager)GetNode("GameManager");
        constructor = (Constructor)GetNode("Constructor");
        canvas = (GameCanvas)GetNode("GameCanvas");
        player.GlobalPosition = level.entrance.spawnPoint.GlobalPosition;
        player.Connect("PlayerDead", this, nameof(_Reset_Level));
    }

    public void _Reset_Level()  // named wrong
    {
        player.Freeze();
        canvas.GameEnded(false);
    }

    public void NextLevel() // named wrong
    {
        player.Freeze();
        canvas.GameEnded(true);
        gameManager.maxLevel++;
        gameManager.Save();
    }

    public void ResetCurrentLevel()
    {
        gameManager.loadLevel(gameManager.currentlevel);
    }

    public void LoadNextLevel()
    {
        gameManager.updateData();
        gameManager.currentlevel++;
        gameManager.Save();
        gameManager.loadLevel(gameManager.currentlevel);
    }

    public void LoadMainMenu()
    {
        gameManager.loadLevel(-1);
    }

    public void _on_GooSprayer_SpawnGoo(Vector2 pos)
    {
        constructor.SpawnGoo(pos);
    }
}
