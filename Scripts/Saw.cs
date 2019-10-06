using Godot;
using System;

public class Saw : Area2D
{
    [Export]
    int turnSpeed = 720;
    private Sprite sprite;
    public override void _Ready()
    {
        sprite = (Sprite)GetNode("Sprite");
    }

    public override void _Process(float delta)
    {
        sprite.Rotation += Mathf.Deg2Rad(turnSpeed) * delta;
    }

    public void _on_Saw_body_entered(PhysicsBody2D body)
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
