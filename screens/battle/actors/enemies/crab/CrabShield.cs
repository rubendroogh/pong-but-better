using Godot;
using System;

public partial class CrabShield : Node2D
{
    private AnimationPlayer MovementPlayer => GetNode<AnimationPlayer>("MovementPlayer");

    public override void _Ready()
    {
        CallDeferred(nameof(ConnectSignals));
    }

    private void ConnectSignals()
    {
        var crabController = BattleController.Instance?.EnemyController as Crab;
        if (crabController == null)
        {
            GD.Print("EnemyController is null");
            return;
        }

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
