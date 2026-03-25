using System;
using Godot;

public partial class Actor : Node, IHittable, IActor
{
    [Export]
    public int MaxHealth { get; set; } = 100;

    public int CurrentHealth { get; set; }

    public int ActorID { get; set; } = 0;

    [Signal]
    public delegate void ActorHitEventHandler(float damage);

    [Signal]
    public delegate void ActorCriticalHitEventHandler(float damage);

    [Signal]
    public delegate void ActorDeathEventHandler();

    public override void _Ready()
    {
        CurrentHealth = MaxHealth;
    }

    public virtual void Hit(int damage, bool critical)
    {
        throw new NotImplementedException();
    }
}
