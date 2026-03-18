using Godot;

public partial class EnemyController : ActorController, IHittable, IActor
{
    public int ActorID { get; set; } = 1;

    [Signal]
    public delegate void EnemyHitEventHandler();

    [Signal]
    public delegate void EnemyCriticalHitEventHandler();

    public override void _Ready()
    {
        base._Ready();
    }

    public void Hit(int damage, bool critical)
    {
        if (critical)
        {
            CurrentHealth -= damage * 2;
            EmitSignal(SignalName.EnemyCriticalHit);
        }
        else
        {
            CurrentHealth -= damage;
            EmitSignal(SignalName.EnemyHit);
        }
    }
}
