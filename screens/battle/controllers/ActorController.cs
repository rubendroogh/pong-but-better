using Godot;

public partial class ActorController : Node
{
    public int MaxHealth { get; set; } = 100;

    public int CurrentHealth { get; set; }

    public override void _Ready()
    {
        CurrentHealth = MaxHealth;
    }
}
