using Godot;

public partial class PlayerController : Node, IHittable
{
    public static PlayerController Instance { get; private set; }

    public int MaxHealth { get; set; } = 100;

    public int CurrentHealth { get; set; }

    [Signal]
    public delegate void PlayerHealthChangeEventHandler(int change);

    public override void _Ready()
    {
        Instance = this;
        CurrentHealth = MaxHealth;
    }

    public void Hit(int damage, bool critical)
    {
        // Critical not implemented yet (if even necessary)
        CurrentHealth -= damage;

        EmitSignal(SignalName.PlayerHealthChange, damage);
    }

    private void Die()
    {
        
    }
}
