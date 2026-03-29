using System.Reflection.Metadata;
using Godot;

public partial class PlayerStats : ActorStats
{
    public override void _Ready()
    {
        CallDeferred(nameof(ConnectSignals));
    }

    private void ConnectSignals()
    {
        var playerController = Player.Instance;
        if (playerController == null)
        {
            GD.Print("PlayerController is null");
            return;
        }

        playerController.ActorHit += HandlePlayerHealthChange;
        playerController.ActorDeath += HandlePlayerDeath;
    }

    private void HandlePlayerHealthChange(float damage)
    {
        HealthBar.MaxValue = Player.Instance.MaxHealth;
        HealthBar.Value = Player.Instance.CurrentHealth;
    }

    private void HandlePlayerDeath()
    {
        Hide();
    }
}
