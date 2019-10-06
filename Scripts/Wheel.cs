using Godot;
using System;

public class Wheel : KinematicBody2D
{
    [Export]
    int turnSpeed = 10;
    public override void _PhysicsProcess(float delta)
    {

        if (turnSpeed > 0)
            Rotate((Mathf.Deg2Rad(10)*delta));
        else
            Rotate(-(Mathf.Deg2Rad(10)*delta));
    }

}
