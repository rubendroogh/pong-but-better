using Godot;

public partial class BattleController : Node
{
    [Export]
    public EnemyController EnemyController { get; private set; }

    [Export]
    public PlayerController PlayerController { get; private set; }

    public static BattleController Instance { get; private set; }

    public override void _Ready()
    {
        if (Instance != null)
        {
            GD.PrintErr("Multiple instances of BattleController detected! This should not happen.");
        }
        
        Instance = this;
    }
}
