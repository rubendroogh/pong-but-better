using Godot;

public partial class Actor : Node
{
    [Export]
    public int MaxHealth { get; set; } = 100;

    public int CurrentHealth { get; set; }

    [Signal]
    public delegate void ActorHitEventHandler(int damage);

    [Signal]
    public delegate void ActorCriticalHitEventHandler(int damage);

    public override void _Ready()
    {
        CurrentHealth = MaxHealth;
    }
}
