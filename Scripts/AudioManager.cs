using Godot;
using System;

public class AudioManager : Node2D
{
    AudioStreamPlayer2D hit;
    AudioStreamPlayer2D jump;
    AudioStreamPlayer2D place;
    AudioStreamPlayer2D remove;
    public override void _Ready()
    {
        hit = (AudioStreamPlayer2D)GetNode("Hit");
        jump = (AudioStreamPlayer2D)GetNode("Jump");
        place = (AudioStreamPlayer2D)GetNode("Place");
        remove = (AudioStreamPlayer2D)GetNode("Remove");
    }

    public void Hit()
    {
        hit.Stop();
        hit.PitchScale = randomPitch();
        hit.Play(0);
    }
    public void Jump()
    {
        jump.Stop();
        jump.PitchScale = randomPitch();
        jump.Play(0);
    }
    public void Place()
    {
        place.Stop();
        place.PitchScale = randomPitch();
        place.Play(0);
    }    
    public void Remove()
    {
        remove.Stop();
        remove.PitchScale = randomPitch();
        remove.Play(0);
    }

    private float randomPitch()
    {
        Random ran = new Random();
        return (float)(ran.Next(5, 10))/10f;
    }
}
