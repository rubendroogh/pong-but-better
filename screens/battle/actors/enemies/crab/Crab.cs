using System;
using Godot;

public partial class Crab : Enemy
{
    [Export]
    private int HideInterval = 10; // Hide interval in seconds

    [Export]
    private int HideLength = 3; // Length of time the head stays hidden in seconds
    
    [Signal]
    public delegate void CrabStartHideEventHandler();

    [Signal]
    public delegate void CrabStartPeekEventHandler();

    private Callable _doHideCallable;

    private Callable _doPeekCallable;

    public override void _Ready()
    {
        base._Ready();

        _doHideCallable = Callable.From(DoHide);
        _doPeekCallable = Callable.From(DoPeek);

        // Schedule the first attack
        ScheduleNextHide();
    }

    protected override void OnCriticalHit(float damage)
    {
        EmitSignal(SignalName.CrabStartHide);
        base.OnCriticalHit(damage);
    }

    private void ScheduleNextHide()
    {
        var randomOffset = new Random().Next(-2, 3); // Random offset between -2 and +2 seconds
        var nextHideTime = HideInterval + randomOffset;

        GetTree().CreateTimer(nextHideTime).Connect("timeout", _doHideCallable);
    }

    private void DoHide()
    {
        EmitSignal(SignalName.CrabStartHide);
        ScheduleNextPeek();
    }

    private void ScheduleNextPeek()
    {
        GetTree().CreateTimer(HideLength).Connect("timeout", _doPeekCallable);
    }

    private void DoPeek()
    {
        EmitSignal(SignalName.CrabStartPeek);
        ScheduleNextHide();
    }
}
