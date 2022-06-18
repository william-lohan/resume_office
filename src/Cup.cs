using Godot;
using System;

public class Cup : Spatial
{
    AudioStreamPlayer3D audioPlayer;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        audioPlayer = GetNode<AudioStreamPlayer3D>("AudioStreamPlayer3D");
    }

    public void _OnCupClick(InputEvent inputEvent, Vector3 position)
    {
        // TODO animate cup
        audioPlayer.Play();
    }
}
