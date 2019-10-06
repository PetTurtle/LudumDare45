using Godot;
using System;

public class Player : RigidBody2D
{
    [Signal]
    public delegate void PlayerDead();
    public int moveSpeed = 5;
    public int jumpForce = 70;
    public int maxSpeed = 50;
    public bool isGround() => groundRay.IsColliding();
    public bool isCollidingLeft() => leftTopRay.IsColliding() || leftBottomRay.IsColliding();
    public bool isCollidingRight() => rightTopRay.IsColliding() || rightBottomRay.IsColliding();
    private AnimatedSprite animation;
    private RayCast2D groundRay;
    private RayCast2D leftTopRay;
    private RayCast2D leftBottomRay;
    private RayCast2D rightTopRay;
    private RayCast2D rightBottomRay;

    public override void _Ready()
    {
        animation = (AnimatedSprite)GetNode("AnimatedSprite");
        groundRay = (RayCast2D)GetNode("GroundRay");
        leftTopRay = (RayCast2D)GetNode("LeftTopRay");
        leftBottomRay = (RayCast2D)GetNode("LeftBottomRay");
        rightTopRay = (RayCast2D)GetNode("RightTopRay");
        rightBottomRay = (RayCast2D)GetNode("RightBottomRay");
    }

    public override void _IntegrateForces(Physics2DDirectBodyState state)
    {
        Vector2 velocity = GetLinearVelocity();
        velocity = updatedVelocity(velocity);
        updateAnimation(velocity);
        SetLinearVelocity(velocity);
        jump();
    }

    public void Kill()
    {
        EmitSignal("PlayerDead");
    }

    public void Freeze()
    {
        GravityScale = 0;
        SetLinearVelocity(Vector2.Zero);
        SetAngularVelocity(0);
    }

    private Vector2 updatedVelocity(Vector2 velocity)
    {
        float motion = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
        velocity.x += motion * moveSpeed;

        if (isCollidingLeft() && velocity.x < 0)
            velocity.x = 0;
        else if (isCollidingRight() && velocity.x > 0)
            velocity.x = 0;

        if (velocity.x > maxSpeed)
            velocity.x = maxSpeed;
        else if (velocity.x < -maxSpeed)
            velocity.x = -maxSpeed;

        return velocity;
    }

    private void jump()
    {
        if (Input.IsActionJustPressed("move_up") && isGround())
        {
            Vector2 velocity = GetLinearVelocity();
            velocity.y = 0;
            SetLinearVelocity(velocity);
            ApplyCentralImpulse(Vector2.Up * jumpForce);
        }
            
    }

    private void updateAnimation(Vector2 velocity)
    {
        animation.SetFlipH(velocity.x < 0);

        if (velocity.Length() > 10 || !isGround())
            animation.SetAnimation("run");
        else
            animation.SetAnimation("default");

        if (!isGround() && (animation.Frame == 0 || animation.Frame == 2))
            animation.SpeedScale = 0;
        else
            animation.SpeedScale = 2;
    }
}
