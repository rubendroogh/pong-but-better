using System;
using Godot;

public partial class Claw : Node
{
    [Export]
    private int AttackInterval = 10; // Attack interval in seconds

    [Export]
    private bool FlippedCirclePath = false;

    [Export]
    private PackedScene ProjectileScene { get; set; }

    private Sprite2D Sprite => FindChild("Sprite2D") as Sprite2D;

    private AnimationPlayer MovementPlayer => GetNode<AnimationPlayer>("MovementPlayer");

    private AnimationPlayer AttackPlayer => GetNode<AnimationPlayer>("AttackPlayer");

    private Node2D ProjectileSpawnPoint => FindChild("ProjectileSpawnPoint") as Node2D;

    private string CircleLoopAnimationName => FlippedCirclePath ? "circle-loop-flipped" : "circle-loop";

    // Reference to the Callable to properly disconnect it later
    private Callable _attackFinishedCallable;

    public override void _Ready()
    {
        _attackFinishedCallable = Callable.From<string>(OnAttackFinished);
        CallDeferred(nameof(ConnectSignals));

        // Start the loop
        MovementPlayer.Play(CircleLoopAnimationName);
        
        // Schedule the first attack
        ScheduleNextAttack();
    }

    private void ConnectSignals()
    {
        var enemyController = BattleController.Instance?.EnemyController;
        if (enemyController == null)
        {
            GD.Print("EnemyController is null");
            return;
        }

        enemyController.ActorCriticalHit += HandleCriticalHit;
    }

    private void HandleCriticalHit(int actorID, int damage)
    {
        StartAttackMode();
    }

    private void ScheduleNextAttack()
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
        MovementPlayer.Play(CircleLoopAnimationName); // Resume the movement
        ScheduleNextAttack();
    }

    private void ShootProjectile()
    {
        var projectileInstance = ProjectileScene.Instantiate<Projectile>();
        projectileInstance.Start(new Vector2(-500, 0)); // Shoot left if flipped, right otherwise
        ProjectileSpawnPoint.AddChild(projectileInstance);
        projectileInstance.Position = Vector2.Zero; // Spawn at the spawn point's position
    }
}
