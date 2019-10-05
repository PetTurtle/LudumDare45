using Godot;
using System;

public class Connector : CollisionShape2D
{

    Anchor a, b;
    private Sprite sprite;

    public override void _EnterTree()
    {
        sprite = (Sprite)GetNode("Sprite");
    }

    public void setShape(Anchor a, Anchor b)
    {
        this.a = a; this.b = b;
        this.GlobalPosition = new Vector2((a.GlobalPosition.x + b.GlobalPosition.x)/2, (a.GlobalPosition.y + b.GlobalPosition.y)/2);
        LookAt(a.Position);

        Vector2 dir = b.GlobalPosition - a.GlobalPosition;
        float length = dir.Length();
        Scale = new Vector2(length/2, sprite.Scale.y*2);
    }
}
