using Godot;
using System;

public class MouseEventCapture : Area
{
    [Signal]
    public delegate void Click(InputEvent inputEvent, Vector3 position);

    [Signal]
    public delegate void Enter();

    [Signal]
    public delegate void Exit();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        InputRayPickable = true;
        Connect("input_event", this, nameof(_OnInputEvent));
        Connect("mouse_entered", this, nameof(_OnMouseEntered));
        Connect("mouse_exited", this, nameof(_OnMouseExited));
    }


    public void _OnInputEvent(Node camera, InputEvent inputEvent, Vector3 position, Vector3 normal, int shape_idx)
    {
        if(inputEvent is InputEventMouseButton mouseEvent)
        {
            if ((mouseEvent.ButtonIndex == (int)ButtonList.Left) && mouseEvent.Pressed) {
                EmitSignal(nameof(Click), inputEvent, position);
            }
        }
    }

    public void _OnMouseEntered()
    {
        EmitSignal(nameof(Enter));
    }

    public void _OnMouseExited()
    {
        EmitSignal(nameof(Exit));
    }
}
