using Godot;
using System;
using System.Collections.Generic;

public class Anchor : RigidBody2D
{
    public bool canConnect() => joints.Count < MAXJOINTS;
    private static int MAXJOINTS = 4;
    private CollisionShape2D collision;
    private bool active = false;
    private List<PinJoint2D> joints = new List<PinJoint2D>();

    public override void _Ready()
    {
        collision = (CollisionShape2D)GetNode("CollisionShape2D");
    }

    public void connect(Anchor anchor)
    {
        if (canConnect())
        {
            PinJoint2D joint = newJoint();
            joint.NodeB = anchor.GetPath();
        }
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

    private PinJoint2D newJoint()
    {
        PinJoint2D joint = new PinJoint2D();
        joint.Position = this.Position;
        joint.NodeA = this.GetPath();
        AddChild(joint);
        return joint;
    }
}
