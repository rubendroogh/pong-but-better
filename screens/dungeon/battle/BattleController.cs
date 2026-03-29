using Godot;

public partial class BattleController : Node
{
    public Enemy EnemyController { get; private set; }

    [Export]
    private ResourcePreloader CommonEnemyPreloader { get; set; }

    [Signal]
    public delegate void BattleStartEventHandler();

    [Signal]
    public delegate void BattleEndEventHandler();

    public static BattleController Instance { get; private set; }

    public override void _Ready()
    {
        if (Instance != null)
        {
            GD.PrintErr("Multiple instances of BattleController detected! This should not happen.");
        }
        
        Instance = this;
        Start();
    }

    public void Start()
    {
        SpawnRandomCommonEnemy();
    }

    private void SpawnRandomCommonEnemy()
    {
        var resourceList = CommonEnemyPreloader.GetResourceList();
        var enemySceneResource = resourceList[GD.Randi() % resourceList.Length];

        var enemyScene = CommonEnemyPreloader.GetResource(enemySceneResource) as PackedScene;
        var enemy = enemyScene.Instantiate<Enemy>();
        AddChild(enemy);

        EnemyController = enemy;
        EnemyController.ActorDeath += OnEnemyDeath;
    }

    private void OnEnemyDeath()
    {
        // Hide enemy sprite and healthbar
        // Enter looting mode
        GD.Print("emenie dided");
    }
}

public enum Mode
{
    Battle,
    Looting
}