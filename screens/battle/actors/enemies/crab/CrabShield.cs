using Godot;
using System;

public partial class CrabShield : Node2D
{
    public override void _Ready()
    {
        CallDeferred(nameof(ConnectSignals));
    }

    private void ConnectSignals()
    {
        var enemyController = BattleController.Instance?.EnemyController;
        if (enemyController == null)
        {
            GD.Print("EnemyController is null");
            return;
        }

        // enemyController.ActorCriticalHit += HandleCriticalHit;
    }
}
