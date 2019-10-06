using Godot;
using System;

public class GooSprayer : StaticBody2D
{
    [Signal]
    public delegate void SpawnGoo();
    [Export]
    int gooCounter = 4;
    [Export]
    float spawnRate = 1;
    float timer = 0;
    private bool spawn = false;

    public override void _Process(float delta)
    {
        if (gooCounter == 0)
            spawn = false;
        
        if (spawn)
        {
            timer += 1*delta;
            if (timer > spawnRate)
            {
                timer = 0;
                EmitSignal("SpawnGoo", this.Position);
                gooCounter--;
            }
        }
    }

    public void _on_PreasurePlate_PlayerEntered()
    {
        spawn = true;
    }
}
