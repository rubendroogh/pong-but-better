using Godot;

public partial class Player : Actor
{
    public static Player Instance { get; private set; }

    public int Money { get; private set; }

    // The shield instance in battle.
    public Shield Shield { get; private set; }

    [Signal]
    public delegate void PlayerDeathEventHandler();

    [Signal]
    public delegate void MoneyChangedEventHandler();

    [Export]
    private ResourcePreloader ShieldsPreloader { get; set; }

    [Export]
    private string ShieldKey { get; set; }

    public override void _Ready()
    {
        ActorID = 0;
        Instance = this;

        // TODO: Spawn shield to keep state

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

    public PackedScene GetShieldScene()
    {
        var shieldScene = ShieldsPreloader.GetResource(ShieldKey) as PackedScene;
        if (shieldScene == null)
        {
            GD.PrintErr("Shield scene not found!");
        }

        return shieldScene;
    }

    public void SetShield(Shield shield)
    {
        Shield = shield;
    }

    private void Die()
    {
        // Do animation
        EmitSignal(SignalName.PlayerDeath);
    }
}

