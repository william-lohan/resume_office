using Godot;
using System;

public class Logic : Spatial
{

    AnimationPlayer animationPlayer;

    AudioStreamPlayer3D resumeAudio;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        resumeAudio = GetNode<AudioStreamPlayer3D>("ResumeArea/AudioStreamPlayer3D");
    }

    public void _OnResumeClick(InputEvent inputEvent, Vector3 position)
    {
        // TODO show resume
        resumeAudio.Play();
    }

    public void _OnLaptopClick(InputEvent inputEvent, Vector3 position)
    {
        // TODO download resume
        OS.ShellOpen("https://asdf.com/");
    }

    public void _OnLaptopMouseEnter()
    {
        animationPlayer.Play("open");
    }

    public void _OnLaptopMouseExit()
    {
        animationPlayer.Play("close");
    }

    public void _OnSoundToggle(bool buttonPressed)
    {
        AudioServer.SetBusMute(0, !buttonPressed);
    }
}
