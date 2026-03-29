using Godot;

public partial class CrabHead : ActorOwned
{
    private AnimationPlayer MovementPlayer => GetNode<AnimationPlayer>("MovementPlayer");

    private bool _isHiding;

    public override void _Ready()
    {
        base._Ready();
        // Connect to the critical hit signal from the EnemyController
        CallDeferred(nameof(ConnectSignals));
    }

    private void ConnectSignals()
    {
        var crabController = OwnerActor as Crab;

        crabController.CrabStartHide += HandleCrabHide;
        crabController.CrabStartPeek += HandleCrabPeek;
    }

    private void HandleCrabHide()
    {
        MovementPlayer.Play("slide-to-right");
    }

    private void HandleCrabPeek()
    {
        MovementPlayer.Play("slide-to-left");
    }
}
