using Godot;
using System;

public class Projectile : Area2D
{
    [Export]
    
    int speed = 20;
    [Export]
    int turnSpeed = 360 * 2;
    public Vector2 direction = new Vector2(-1, 0);

    private Sprite sprite;
    public override void _Ready()
    {
        sprite = (Sprite)GetNode("Sprite");
    }
    public override void _Process(float delta)
    {
        Position += direction * speed * delta;
        sprite.Rotation += Mathf.Deg2Rad(turnSpeed) * delta;
    }

    public void _on_Projectile_body_entered(PhysicsBody2D body)
    {
        if (body is Player)
        {
            GD.Print("PLAYER!");
        }
        else if (body is Anchor)
        {
            Anchor anchor = (Anchor) body;
            anchor.removeClosestBrace(this.GlobalPosition);
        }
        else if (body.Name.Equals("TileMap"))
        {
            QueueFree();
        }
    }
}
