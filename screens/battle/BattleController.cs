using Godot;

public partial class BattleController : Node
{
    public Enemy EnemyController { get; private set; }

    [Export]
    private ResourcePreloader CommonEnemyPreloader { get; set; }

    public static BattleController Instance { get; private set; }

    public override void _Ready()
    {
        if (Instance != null)
        {
            GD.PrintErr("Multiple instances of BattleController detected! This should not happen.");
        }
        
        SpawnRandomCommonEnemy();
        Instance = this;
    }

    private void SpawnRandomCommonEnemy()
    {
        var resourceList = CommonEnemyPreloader.GetResourceList();
        var enemySceneResource = resourceList[GD.Randi() % resourceList.Length];

        var enemyScene = CommonEnemyPreloader.GetResource(enemySceneResource) as PackedScene;
        var enemy = enemyScene.Instantiate<Enemy>();
        AddChild(enemy);

        EnemyController = enemy;
    }
}
