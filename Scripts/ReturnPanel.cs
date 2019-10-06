using Godot;
using System;

public class ReturnPanel : Panel
{
    public override void _Ready()
    {
        
    }

    public void _on_ButtonNo_pressed()
    {
        this.Visible = false;
    }
}
