using Godot;

public partial class Player : Actor
{
    public static Player Instance { get; private set; }

    public int Money { get; private set; }

    [Signal]
    public delegate void PlayerDeathEventHandler();

    [Signal]
    public delegate void MoneyChangedEventHandler();

    public override void _Ready()
    {
        ActorID = 0;
        Instance = this;
        base._Ready();
    }

    // Critical not implemented yet (if even necessary)
    public override void Hit(int damage, bool critical)
    {
        CurrentHealth -= damage;
        EmitSignal(SignalName.ActorHit, damage);

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void AddMoney(int valueToAdd)
    {
        Money += valueToAdd;
        EmitSignal(SignalName.MoneyChanged);
    }

    private void Die()
    {
        // Do animation
        EmitSignal(SignalName.PlayerDeath);
    }
}
