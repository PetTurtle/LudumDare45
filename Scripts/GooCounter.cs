using Godot;
using System;

public class GooCounter : TextureRect
{
    Label label;
    TextureProgress progress;
    public override void _Ready()
    {
        label = (Label)GetNode("Label");
        progress = (TextureProgress)GetNode("TextureProgress");
    }

    public void SetValue(int value)
    {
        label.Text = value.ToString();
        progress.Value = value;
    }
}
