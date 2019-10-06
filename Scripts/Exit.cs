using Godot;
using System;

public class Exit : StaticBody2D
{
    [Signal]
    public delegate void PlayerEntered();

    public void _on_Area2D_body_entered(PhysicsBody2D body)
    {
        
        if (body is Player)
        {   
            EmitSignal("PlayerEntered");
        }
            
    }
}
