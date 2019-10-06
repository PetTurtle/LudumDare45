using Godot;
using System;

public class KillZone : Area2D
{
    public void _on_KillZone_body_entered(PhysicsBody2D body)
    {
        if (body is Player)
        {
            ((Player) body).Kill();
        }
        else if (body is Anchor)
        {
            Anchor anchor = (Anchor) body;
            anchor.removeClosestBrace(this.GlobalPosition);
        }
    }
}
