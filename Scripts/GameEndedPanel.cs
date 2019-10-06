using Godot;
using System;

public class GameEndedPanel : Panel
{
    [Signal]
    public delegate void Back();
    [Signal]
    public delegate void Next();
    [Signal]
    public delegate void Retry();
    private Label message;
    private Button back;
    private Button next;
    private bool won = true;
    public override void _Ready()
    {
        message = (Label)GetNode("Message");
        back = (Button)GetNode("ButtonBack");
        next = (Button)GetNode("ButtonNext");
    }

    public void Display(bool won)
    {
        this.won = won;
        this.Visible = true;
        if (!won)
        {
            message.Text = "Game Over!!";
            next.Text = "Retry";
        }
    }

    public void BackPressed()
    {
        EmitSignal("Back");
    }

    public void NextPressed()
    {
        if (won)
            EmitSignal("Next");
        else
            EmitSignal("Retry");
    }
}
