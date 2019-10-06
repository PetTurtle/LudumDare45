using Godot;
using System;
using System.Collections.Generic;

public class LevelSelector : GridContainer
{
    
    List<Button> buttons;

    public override void _Ready()
    {
        buttons = new List<Button>();

        foreach(Button button in GetChildren())
        {
            buttons.Add(button);
        }
    }

    public void EnableUpTo(int num)
    {
        for(int i = 0; i < num + 1 && i < buttons.Count; i++)
        {
            buttons[i].Disabled = false;
        }
    }

    public void addSignal(GameManager manager)
    {
        
    }

    
}
