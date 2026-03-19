using Godot;

public partial class EnemyHealthBar : HealthBar
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

    private void HandleEnemyHit(int damage)
    {
        var enemyController = BattleController.Instance?.EnemyController;
        MaxValue = enemyController.MaxHealth;
        Value = enemyController.CurrentHealth;
    }
}
