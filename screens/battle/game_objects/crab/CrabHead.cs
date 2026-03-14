using Godot;
using System;

public partial class CrabHead : Node2D
{
    [Export]
    private int HideInterval = 10; // Hide interval in seconds

    [Export]
    private int HideLength = 3; // Length of time the head stays hidden in seconds

    private AnimationPlayer MovementPlayer => GetNode<AnimationPlayer>("MovementPlayer");

    private Callable _doHideCallable;

    private Callable _doPeekCallable;

    public override void _Ready()
    {
        _doHideCallable = Callable.From(DoHide);
        _doPeekCallable = Callable.From(DoPeek);

        // Connect to the critical hit signal from the EnemyController
        CallDeferred(nameof(ConnectSignals));

        // Schedule the first attack
        ScheduleNextHide();
    }

    private void ConnectSignals()
    {
        var enemyController = BattleController.Instance?.EnemyController;
        if (enemyController == null)
        {
            GD.Print("EnemyController is null");
            return;
        }

        enemyController.CriticalHit += HandleCriticalHit;
    }

    private void HandleCriticalHit()
    {
        GD.Print("Crab head hit by critical hit!");
        DoHide();
    }

    private void ScheduleNextHide()
    {
        var randomOffset = new Random().Next(-2, 3); // Random offset between -2 and +2 seconds
        var nextAttackTime = HideInterval + randomOffset;

        GetTree().CreateTimer(nextAttackTime).Connect("timeout", _doHideCallable);
    }

    private void DoHide()
    {
        MovementPlayer.Play("slide-to-right");
        ScheduleNextPeek();
    }

    private void ScheduleNextPeek()
    {
        GetTree().CreateTimer(HideLength).Connect("timeout", _doPeekCallable);
    }

    private void DoPeek()
    {
        MovementPlayer.Play("slide-to-left");
        ScheduleNextHide();
    }
}
