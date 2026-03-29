using Godot;

public partial class EnemyStats : ActorStats
{
    public override void _Ready()
    {
        CallDeferred(nameof(ConnectSignals));
    }

    private void ConnectSignals()
    {
        var enemyController = BattleController.Instance?.EnemyController;
        if (enemyController == null)
        {
            GD.Print("EnemyController is null");
            return;
        }

        enemyController.ActorHit += HandleEnemyHit;
        enemyController.ActorCriticalHit += HandleEnemyHit;
    }

    private void HandleEnemyHit(float damage)
    {
        var enemyController = BattleController.Instance?.EnemyController;
        HealthBar.MaxValue = enemyController.MaxHealth;
        HealthBar.Value = enemyController.CurrentHealth;
    }
}
