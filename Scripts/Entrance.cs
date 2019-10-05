using Godot;
using System;

public class Entrance : StaticBody2D
{
    public Node2D spawnPoint;
    public override void _Ready()
    {
        spawnPoint = (Node2D)GetNode("SpawnPoint");
    }
}
