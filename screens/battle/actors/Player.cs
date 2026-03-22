using Godot;

public partial class Player : Actor, IHittable, IActor
{
    public static Player Instance { get; private set; }

    public int ActorID { get; set; } = 0;

    [Signal]
    public delegate void PlayerDeathEventHandler();

    public override void _Ready()
    {
        Instance = this;
        base._Ready();
    }

    // Critical not implemented yet (if even necessary)
    public void Hit(int damage, bool critical)
    {
        CurrentHealth -= damage;
        EmitSignal(SignalName.ActorHit, damage);

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Do animation
        EmitSignal(SignalName.PlayerDeath);
    }
}
