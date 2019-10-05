using Godot;
using System;

public class Connector : CollisionShape2D
{
    private Sprite sprite;
    private Brace a, b;

    public override void _EnterTree()
    {
        sprite = (Sprite)GetNode("Sprite");
    }

    public void setShape(Brace a, Brace b)
    {
        this.a = a; this.b = b;
        this.GlobalPosition = new Vector2((a.GlobalPosition.x + b.GlobalPosition.x)/2, (a.GlobalPosition.y + b.GlobalPosition.y)/2);
        LookAt(a.GlobalPosition);
        float length = (b.GlobalPosition - a.GlobalPosition).Length();
        this.Scale = new Vector2(length/2, sprite.Scale.y);
        a.addConnectorToList(this);
        b.addConnectorToList(this);
    }

    public void setActive(bool value)
    {
        if (value) {
            Disabled = false;
        } else {
            Disabled = true;
        }
    }

    public void remove()
    {
        a.removeConnectorFromList(this);
        b.removeConnectorFromList(this);
        this.QueueFree();
    }
}
