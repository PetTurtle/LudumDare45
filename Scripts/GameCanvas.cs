using Godot;
using System;

public class GameCanvas : CanvasLayer
{
    GooCounter gooCounter;
    GameEndedPanel endedPanel;
    ReturnPanel returnPanel;

    public override void _Ready()
    {
        gooCounter = (GooCounter)GetNode("GooCounter");
        endedPanel = (GameEndedPanel)GetNode("GameEndedPanel");
        returnPanel = (ReturnPanel)GetNode("ReturnPanel");
        setGoo(0);
    }

    public override void _Process(float delta)
    {
        if (Input.IsActionJustPressed("escape") && !endedPanel.Visible)
        {
            returnPanel.Visible = !returnPanel.Visible;
        }
    }

    public void setGoo(int amount)
    {
        gooCounter.SetValue(amount);
    }

    public void GameEnded(bool won)
    {
        returnPanel.Visible = false;
        endedPanel.Display(won);
    }
}
