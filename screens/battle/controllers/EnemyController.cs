using Godot;

public partial class EnemyController : Node, IHittable
{
    public int MaxHealth = 100;

    public int CurrentHealth { get; private set; } // Use SetCurrentHealth

    [Signal]
    public delegate void EnemyHitEventHandler();

    [Signal]
    public delegate void EnemyCriticalHitEventHandler();

    public override void _Ready()
    {
        CurrentHealth = MaxHealth;
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
