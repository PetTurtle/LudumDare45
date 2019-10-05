using Godot;
using System;
using GC = Godot.Collections;
using SC = System.Collections.Generic;

public class Brace : CollisionShape2D
{
    private Sprite sprite;
    public Anchor anchor;
    SC.List<Connector> connectors = new SC.List<Connector>();

    public override void _EnterTree()
    {
        sprite = (Sprite)GetNode("Sprite");
    }

    public void connect(Brace brace)
    {
        var connectorScene = GD.Load<PackedScene>("res://Scenes/Assets/Connector.tscn");
        Connector connector = (Connector) connectorScene.Instance();
        GetParent().AddChild(connector);
        connector.setShape(this, brace);
    }

    public bool canSee(Brace brace)
    {
        bool value = true;
        var spaceState = GetWorld2d().DirectSpaceState;
        var terrainResult = spaceState.IntersectRay(this.GlobalPosition, brace.GlobalPosition, null, 1);
        if (terrainResult.Count > 0)
            value = false;
        
        return value;
    }

    public void setActive(bool value)
    {
        if (value) {
            Disabled = false;
        } else {
            Disabled = true;
        }
        connectorToggle(value);
    }

    public void remove()
    {
        // if (connectors != null && connectors.Count > 0)
        //     foreach(Connector connector in connectors)
        //         connector.remove();
        
        if (anchor != null)
            anchor.removeBraceFromList(this);
        this.QueueFree();
    }

    public void addConnectorToList(Connector connector)
    {
        connectors.Add(connector);
    }

    public void removeConnectorFromList(Connector connector)
    {
        connectors.Remove(connector);
    }

    private void connectorToggle(bool state)
    {
        foreach(Connector connector in connectors)
        {
            connector.setActive(state);
        }
    }
}
