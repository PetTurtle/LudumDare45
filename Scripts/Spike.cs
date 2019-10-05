using Godot;
using System;

public class Spike : Area2D
{
    [Export]
    bool animate = true;
    private AnimatedSprite animation;
    private CollisionShape2D collision;
    public override void _Ready()
    {
        animation = (AnimatedSprite)GetNode("AnimatedSprite");
        collision = (CollisionShape2D)GetNode("CollisionShape2D");
        if (!animate)
        {
            animation.Stop();
            animation.SetFrame(6);
        }
    }

    public override void _Process(float delta)
    {
        collision.Disabled = !(animation.GetFrame() >= 5);
    }

    public void _on_Spike_body_entered(PhysicsBody2D body)
    {
        if (animation.GetFrame() >= 5)
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

}
