using Godot;
using System;

public class ProjectileLauncher : StaticBody2D
{
    [Export]
    int fireDelay = 5;
    float timer = 0;
    public override void _Ready()
    {
        
    }

    public override void _Process(float delta)
    {
        timer += 1*delta;
        if (timer > fireDelay)
        {
            timer = 0;
            fire();
        }
    }

    private void fire()
    {
        var projectileScene = GD.Load<PackedScene>("res://Scenes/Assets/Projectile.tscn");
        Projectile projectile = (Projectile) projectileScene.Instance();
        GetParent().AddChild(projectile);
        projectile.GlobalPosition = this.GlobalPosition;
        projectile.direction = new Vector2(-Scale.x, 0);
    }
}
