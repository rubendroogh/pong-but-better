public partial class Enemy : Actor, IHittable, IActor
{
    public int ActorID { get; set; } = 1;

    protected virtual float CritMultiplier { get; set; } = 2f;

    public override void _Ready()
    {
        base._Ready();
    }

    public void Hit(int damage, bool critical)
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
