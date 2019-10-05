using Godot;
using System;
using System.Collections.Generic;

public class Anchor : RigidBody2D
{
    public bool canConnect() => braces.Count < MAXJOINTS;
    private static int MAXJOINTS = 4;
    private CollisionShape2D collision;
    private bool active = false;
    private List<Brace> braces = new List<Brace>();

    public override void _Ready()
    {
        collision = (CollisionShape2D)GetNode("CollisionShape2D");
    }

    public void connect(Anchor anchor)
    {
        if (canConnect())
        {
            var braceScene = GD.Load<PackedScene>("res://Scenes/Assets/Brace.tscn");
            Brace brace = (Brace) braceScene.Instance();
            braces.Add(brace);
            brace.set(this, anchor);
        }
    }

    public void addBrace(Brace brace)
    {
        braces.Add(brace);
    }

    public void removeBrace(Brace brace)
    {
        braces.Remove(brace);
    }

    public void setActive(bool value)
    {
        if (value) {
            active = true;
            collision.Disabled = false;
            this.Mode = ModeEnum.Rigid;
        } else {
            active = false;
            collision.Disabled = true;
            this.Mode = ModeEnum.Static;
        }
    }

    public void destory()
    {
        this.QueueFree();
    }
}
