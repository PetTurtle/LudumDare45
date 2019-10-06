using Godot;
using System;
using System.Collections.Generic;

public class LevelSelector : GridContainer
{
    [Signal]
    public delegate void LoadLevel();
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

    public void _load_level_1()
    {
        EmitSignal("LoadLevel", 0);
    }

    public void _load_level_2()
    {
        EmitSignal("LoadLevel", 1);
    }
    
    public void _load_level_3()
    {
        EmitSignal("LoadLevel", 2);
    }

    public void _load_level_4()
    {
        EmitSignal("LoadLevel", 3);
    }

    public void _load_level_5()
    {
        EmitSignal("LoadLevel", 4);
    }

    public void _load_level_6()
    {
        EmitSignal("LoadLevel", 5);
    }

    public void _load_level_7()
    {
        EmitSignal("LoadLevel", 6);
    }

    public void _load_level_8()
    {
        EmitSignal("LoadLevel", 7);
    }

    public void _load_level_9()
    {
        EmitSignal("LoadLevel", 8);
    }
    
}
