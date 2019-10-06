using Godot;
using System;

public class Menu : Node2D
{

    private GameManager manager;
    private CanvasLayer canvas;
    private VBoxContainer menuBox;
    private GridContainer levelsGrid;
    private LevelSelector levelSelector;
    private Button playButton;

    public override void _Ready()
    {
        manager = (GameManager)GetNode("GameManager");
        canvas = (CanvasLayer)GetNode("CanvasLayer");
        menuBox = (VBoxContainer)canvas.GetNode("VBoxContainer");
        levelsGrid = (GridContainer)canvas.GetNode("GridContainer");
        playButton = (Button)menuBox.GetNode("ButtonPlayer");

        if (manager.currentlevel != 0)
            playButton.Text = "Continue";

        manager.updateData();
        levelSelector = (LevelSelector)levelsGrid;
        levelSelector.EnableUpTo(manager.maxLevel);
    }

    public void _on_Button_pressed_player()
    {
        manager.loadLevel(manager.currentlevel);
    }
    
    public void _on_ButtonLvls_pressed()
    {
        levelSelector.Visible = !levelSelector.Visible;
    }

    public void _on_ButtonExit_pressed()
    {
        GetTree().Quit();
    }

    public void _on_GridContainer_LoadLevel(int level)
    {
        manager.currentlevel = level;
        manager.Save();
        manager.loadLevel(level);
    }
}
