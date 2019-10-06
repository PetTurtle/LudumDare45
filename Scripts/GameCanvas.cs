using Godot;
using System;

public class GameCanvas : CanvasLayer
{

    GooCounter gooCounter;

    public override void _Ready()
    {
        gooCounter = (GooCounter)GetNode("GooCounter");
        
        setGoo(0);
    }

    public override void _Process(float delta)
    {
        
    }

    public void setGoo(int amount)
    {
        gooCounter.SetValue(amount);
    }
}
