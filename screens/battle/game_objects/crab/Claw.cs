using System;
using Godot;

public partial class Claw : Node
{
    // Loop: do a circle, shoot once every x seconds (+/- random number)

    [Export]
    private int AttackInterval = 10; // Attack interval in seconds

    private Sprite2D Sprite => GetNode<Sprite2D>("Sprite2D");

    private AnimationPlayer MovementPlayer => GetNode<AnimationPlayer>("MovementPlayer");

    private AnimationPlayer AttackPlayer => GetNode<AnimationPlayer>("AttackPlayer");

    // Reference to the Callable to properly disconnect it later
    private Callable _attackFinishedCallable;

    public override void _Ready()
    {
        _attackFinishedCallable = Callable.From<string>(OnAttackFinished);
        Start();
    }

    private void Start()
    {
        // Start the loop
        MovementPlayer.Play("circle-loop");
        
        // Schedule the first attack
        IdleAndScheduleNextAttack();
    }

    private void IdleAndScheduleNextAttack()
    {
        var randomOffset = new Random().Next(-2, 3); // Random offset between -2 and +2 seconds
        var nextAttackTime = AttackInterval + randomOffset;

        GetTree().CreateTimer(nextAttackTime).Connect("timeout", Callable.From(StartAttackMode));
    }

    // Attack mode is the animation of the claw opening, but not shooting yet.
    private void StartAttackMode()
    {
        // Disconnect if already connected to avoid duplicates
        if (AttackPlayer.IsConnected("animation_finished", _attackFinishedCallable))
        {
            AttackPlayer.Disconnect("animation_finished", _attackFinishedCallable);
        }

        // Play the attack animation
        MovementPlayer.Pause();
        AttackPlayer.Play("attack");
        AttackPlayer.Connect("animation_finished", _attackFinishedCallable);
    }

    private void OnAttackFinished(string name)
    {
        MovementPlayer.Play("circle-loop"); // Resume the movement
        IdleAndScheduleNextAttack();
    }
}
