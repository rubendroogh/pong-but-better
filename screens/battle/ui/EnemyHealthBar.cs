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

        enemyController.EnemyHit += HandleEnemyHit;
        enemyController.EnemyCriticalHit += HandleEnemyHit;
    }

    private void HandleEnemyHit()
    {
        var enemyController = BattleController.Instance?.EnemyController;
        MaxValue = enemyController.MaxHealth;
        Value = enemyController.CurrentHealth;
    }
}
