using Godot;

public partial class CrabHead : Node2D
{
    private AnimationPlayer MovementPlayer => GetNode<AnimationPlayer>("MovementPlayer");

    private bool _isHiding;

    public override void _Ready()
    {
        // Connect to the critical hit signal from the EnemyController
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
        MovementPlayer.Play("slide-to-right");
    }

    private void HandleCrabPeek()
    {
        MovementPlayer.Play("slide-to-left");
    }
}
