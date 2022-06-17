using Godot;
using System;

public class Logic : Spatial
{
    Camera camera;

    AnimationPlayer animationPlayer;

    Vector2 target = Vector2.Zero;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        camera = GetNode<Camera>("Tripod/Camera");
        animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
    }

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
        camera.Rotation = new Vector3(
            -rotateTo.y,
            -rotateTo.x,
            camera.Rotation.z
        );
    }

    public void _OnResumeClick(InputEvent inputEvent, Vector3 position)
    {
        // TODO animate cup
        GD.Print("resume clicked");
    }

    public void _OnDeskClick(InputEvent inputEvent, Vector3 position)
    {
        // TODO play knock
        GD.Print("desk clicked");
    }

    public void _OnLaptopClick(InputEvent inputEvent, Vector3 position)
    {
        // TODO download resume
        GD.Print("laptop clicked");
    }

    public void _OnLaptopMouseEnter()
    {
        animationPlayer.Play("open");
    }

    public void _OnLaptopMouseExit()
    {
        animationPlayer.Play("close");
    }

    public void _OnCupClick(InputEvent inputEvent, Vector3 position)
    {
        // TODO animate cup
        GD.Print("cup clicked");
    }
}
