using Godot;

public partial class EnemyController : Node, IHittable
{
    public int MaxHealth = 100;

    public int CurrentHealth { get; private set; }

    [Signal]
    public delegate void CriticalHitEventHandler();

    public override void _Ready()
    {
        CurrentHealth = MaxHealth;
    }

    public void Hit(int damage, bool critical)
    {
        if (critical)
        {
            EmitSignal(nameof(CriticalHit));
            CurrentHealth -= damage * 2;
        }
        else
        {
            CurrentHealth -= damage;
        }
    }
}
