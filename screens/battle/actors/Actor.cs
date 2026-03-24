using Godot;

public partial class Actor : Node
{
    [Export]
    public int MaxHealth { get; set; } = 100;

    public int CurrentHealth { get; set; }

    [Signal]
    public delegate void ActorHitEventHandler(float damage);

    [Signal]
    public delegate void ActorCriticalHitEventHandler(float damage);

    public override void _Ready()
    {
        CurrentHealth = MaxHealth;
    }
}
