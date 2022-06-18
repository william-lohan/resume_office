using Godot;
using System;

public class Camera : Godot.Camera
{
    Vector2 target = Vector2.Zero;

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseMotion mouseMotion)
        {
            Viewport viewport = GetViewport();
            Vector2 mousePosition = viewport.GetMousePosition();
            Vector2 viewportSize = viewport.Size;
            target = mousePosition / viewportSize;
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        Vector2 range = new Vector2(0.1f, 0.1f);
        Vector2 rotateTo = (target * range) - (range / 2);
        Rotation = new Vector3(
            -rotateTo.y,
            -rotateTo.x,
            Rotation.z
        );
    }
}
