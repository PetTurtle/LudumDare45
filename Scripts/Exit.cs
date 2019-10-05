using Godot;
using System;

public class Exit : StaticBody2D
{
    [Signal]
    public delegate void PlayerExit();
    public Area2D exitArea;
    public override void _Ready()
    {
        exitArea = (Area2D)GetNode("Area2D");
    }

    public void _on_Area2D_body_entered(PhysicsBody2D body)
    {
        if (body is Player)
            EmitSignal("PlayerExit");
    }
}
