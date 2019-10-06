using Godot;
using System;

public class Level : Node2D
{
    public Entrance entrance;
    public Exit exit;
    private Game game;
    public override void _Ready()
    {
        entrance = (Entrance)GetNode("Entrance");
        exit = (Exit)GetNode("Exit");
        game = (Game)GetParent();
    }

    public void _on_Exit_PlayerEntered()
    {
        GD.Print("player exitaaaaa");
        game.NextLevel();
    }
}
