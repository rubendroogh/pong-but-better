using Godot;

// An object that simply plays an animation on ready
public partial class OneShotAnimation : Node2D
{
    [Export]
    private AnimationPlayer AnimationPlayer { get; set; }

    public override void _Ready()
    {
        AnimationPlayer.Play("animation");
    }
}
