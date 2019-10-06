using Godot;
using System;

public class PreasurePlate : Area2D
{
    [Signal]
    public delegate void PlayerEntered();
    
    public void _on_PreasurePlate_body_entered(PhysicsBody2D body)
    {
        if (body is Player)
            EmitSignal("PlayerEntered");
    }
}
