public partial class Enemy : Actor
{
    protected virtual float CritMultiplier { get; set; } = 2f;

    public override void _Ready()
    {
        ActorID = 1;
        base._Ready();
    }

    public override void Hit(int damage, bool critical)
    {
        if (critical)
        {
            OnCriticalHit(damage);
        }
        else
        {
            OnHit(damage);
        }
    }

    protected virtual void OnCriticalHit(float damage)
    {
        CurrentHealth -= (int)(damage * CritMultiplier);
        EmitSignal(SignalName.ActorCriticalHit, damage * CritMultiplier);

        if (CurrentHealth <= 0)
        {
            OnDeath();
        }
    }

    protected virtual void OnHit(float damage)
    {
        CurrentHealth -= (int)damage;
        EmitSignal(SignalName.ActorHit, damage);

        if (CurrentHealth <= 0)
        {
            OnDeath();
        }
    }

    protected virtual void OnDeath()
    {
        EmitSignal(SignalName.ActorDeath);
    }
}
