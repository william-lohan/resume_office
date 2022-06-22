using Godot;
using System;

public class Logic : Spatial
{

    AnimationPlayer animationPlayer;

    AudioStreamPlayer3D resumeAudio;

    AnimationPlayer resumeAnimationPlayer;

    AnimationPlayer resumeAnimationPlayer2;

    int step = 0;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        resumeAudio = GetNode<AudioStreamPlayer3D>("ResumeArea/AudioStreamPlayer3D");
        resumeAnimationPlayer = GetNode<AnimationPlayer>("ResumeAnimationPlayer");
        resumeAnimationPlayer2 = GetNode<AnimationPlayer>("ResumeAnimationPlayer2");
    }

    public void _OnResumeClick(InputEvent inputEvent, Vector3 position)
    {
        resumeAudio.Play();
        switch(step) {
            case 0:
            {
                resumeAnimationPlayer.Play("View0");
                step++;
                break;
            }
            case 1:
            {
                resumeAnimationPlayer.Play("Replace0");
                resumeAnimationPlayer2.Play("View1");
                step++;
                break;
            }
            case 2:
            {
                resumeAnimationPlayer2.Play("Replace1");
                step = 0;
                break;
            }
            default:
            {
                resumeAnimationPlayer.Play("RESET");
                resumeAnimationPlayer2.Play("RESET");
                step = 0;
                break;
            }
        }
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
