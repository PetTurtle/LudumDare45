using Godot;
using System;

public class Brace : Node2D
{
    private Anchor a, b;
    private PinJoint2D joint;
    private Connector connector;

    public void set(Anchor a, Anchor b)
    {
        this.a = a;
        this.b = b;
        setConnector();
        a.AddChild(connector);
        a.GetParent().AddChild(connector);
        connector.setShape(a, b);
        setJoint();
        b.addBrace(this);
        a.GetParent().AddChild(this);
    }

    public void removeBrace()
    {
        a.removeBrace(this);
        b.removeBrace(this);
        this.QueueFree();
    }

    private void setJoint()
    {
        joint = new PinJoint2D();
        a.AddChild(joint);
        a.SetLinearVelocity(Vector2.Zero);
        b.SetLinearVelocity(Vector2.Zero);
        joint.GlobalPosition = a.GlobalPosition;
        joint.NodeA = a.GetPath();
        joint.NodeB = b.GetPath();
    }

    private void setConnector()
    {
        var connectorScene = GD.Load<PackedScene>("res://Scenes/Assets/Connector.tscn");
        connector = (Connector)connectorScene.Instance();
    }
}
