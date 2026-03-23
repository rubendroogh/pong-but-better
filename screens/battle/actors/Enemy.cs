public partial class Enemy : Actor, IHittable, IActor
{
    public int ActorID { get; set; } = 1;

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

    protected virtual void OnCriticalHit(int damage)
    {
        CurrentHealth -= damage * 2;
        EmitSignal(SignalName.ActorCriticalHit, damage * 2);
    }

    protected virtual void OnHit(int damage)
    {
        CurrentHealth -= damage;
        EmitSignal(SignalName.ActorHit, damage);
    }
}
