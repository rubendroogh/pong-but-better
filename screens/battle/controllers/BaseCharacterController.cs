using Godot;
using System;

public partial class BaseCharacterController : Node, IHittable
{
    public int MaxHealth = 100;

    public int CurrentHealth { get; private set; } // Use SetCurrentHealth

    [Export]
    private HealthBar HealthBar { get; set; }

    [Signal]
    public delegate void CriticalHitEventHandler();

    public override void _Ready()
    {
        SetCurrentHealth(MaxHealth);
        HealthBar.MaxValue = MaxHealth;
        HealthBar.Value = CurrentHealth;
    }

    public void Hit(int damage, bool critical)
    {
        int newHealth;
        if (critical)
        {
            EmitSignal(nameof(CriticalHit));
            newHealth = CurrentHealth - damage * 2;
        }
        else
        {
            newHealth = CurrentHealth -= damage;
        }

        SetCurrentHealth(newHealth);
    }

    protected void SetCurrentHealth(int newValue)
    {
        CurrentHealth = newValue;
        HealthBar.Value = CurrentHealth;
    }
}
