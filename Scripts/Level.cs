using Godot;
using System;

public class Level : Node2D
{
    public Entrance entrance;
    public Exit exit;
    public override void _Ready()
    {
        entrance = (Entrance)GetNode("Entrance");
        exit = (Exit)GetNode("Exit");
    }
}
