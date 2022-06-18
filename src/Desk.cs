using Godot;
using System;

public class Desk : Spatial
{
    AudioStreamPlayer3D audioPlayer;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        audioPlayer = GetNode<AudioStreamPlayer3D>("AudioStreamPlayer3D");
    }

    public void _OnDeskClick(InputEvent inputEvent, Vector3 position)
    {
        audioPlayer.Play();
    }
}
