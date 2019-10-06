using Godot;
using System;

public class GooCounter : TextureRect
{
    private Label label;
    private TextureProgress progress;
    
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
