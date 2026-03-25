using Godot;
using System;

public partial class CrabShield : ActorOwned
{
    private AnimationPlayer MovementPlayer => GetNode<AnimationPlayer>("MovementPlayer");

    public override void _Ready()
    {
        base._Ready();
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
        MovementPlayer.Play("slide-to-left");
    }

    private void HandleCrabPeek()
    {
        MovementPlayer.Play("slide-to-right");
    }
}
