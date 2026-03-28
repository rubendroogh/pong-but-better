using Godot;

public partial class TransientDamageNumber : Label
{
    [Export]
    private AnimationPlayer AnimationPlayer { get; set; }

    public override void _Ready()
    {
        AnimationPlayer.Play("biggen_and_disappear");
    }
}
