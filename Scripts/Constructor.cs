using Godot;
using System;
using SC = System.Collections.Generic;
using GC = Godot.Collections;

public class Constructor : Node2D
{
    private Anchor activeAnchor;
    private Anchor startAnchor;
    private SC.List<Anchor> anchors = new SC.List<Anchor>();
    private bool hasActiveAnchor() => activeAnchor != null;

    public override void _Ready()
    {
        
    }

    public override void _Process(float delta)
    {
        if (hasActiveAnchor())
        {
            activeAnchor.Position = GetGlobalMousePosition();

            if (Input.IsActionJustReleased("spawn_anchor"))
            {
                if (rayCastinTerrain() || rayCastinPlayer())
                {
                    activeAnchor.destory();
                    activeAnchor = null;
                }
                else if (rayCastinAnchor())
                {
                    activeAnchor.destory();
                    activeAnchor = getRayCastAnchor();
                    if (activeAnchor != startAnchor && startAnchor.canConnect() && activeAnchor.canConnect())
                    {
                        activeAnchor.connect(startAnchor);
                    }
                    activeAnchor = null;
                }
                else // Placing anchor into world
                {
                    activeAnchor.setActive(true);
                    anchors.Add(activeAnchor);

                    if (startAnchor != null && startAnchor.canConnect()) // connect to start anchor TEMP
                        startAnchor.connect(activeAnchor);

                    activeAnchor = null;
                    startAnchor = null;
                }
            }
        }
        else // does not have active anchor
        {
            if (Input.IsActionJustPressed("spawn_anchor") && !rayCastinTerrain())
            {
                activeAnchor = newAnchor(GetGlobalMousePosition());
                startAnchor = getRayCastAnchor();
            }
        }
    }

    private Anchor newAnchor(Vector2 position)
    {
        var anchorScene = GD.Load<PackedScene>("res://Scenes/Assets/Anchor.tscn");
        Anchor anchor = (Anchor) anchorScene.Instance();
        anchor.Position = position;  
        AddChild(anchor);
        return anchor;
    }


    private Anchor getRayCastAnchor() {
        var spaceState = GetWorld2d().GetDirectSpaceState();
        GC.Array result = spaceState.IntersectPoint(GetGlobalMousePosition(), 32, null, 4); // add collision layer

        Anchor anchor = null;
        foreach(GC.Dictionary dic in result)
        {
            anchor = (Anchor) dic["collider"];
        }        
        return anchor;
    }
    private bool rayCastinTerrain() {
        var spaceState = GetWorld2d().GetDirectSpaceState();
        var result = spaceState.IntersectPoint(GetGlobalMousePosition(), 32, null, 1); // add collision layer
        return result.Count != 0;
    }
    private bool rayCastinPlayer() {
        var spaceState = GetWorld2d().GetDirectSpaceState();
        var result = spaceState.IntersectPoint(GetGlobalMousePosition(), 32, null, 2); // add collision layer
        return result.Count != 0;
    }
    private bool rayCastinAnchor() {
        var spaceState = GetWorld2d().GetDirectSpaceState();
        var result = spaceState.IntersectPoint(GetGlobalMousePosition(), 32, null, 4); // add collision layer
        return result.Count != 0;
    }
}
