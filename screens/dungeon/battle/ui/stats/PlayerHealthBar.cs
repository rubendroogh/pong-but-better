using Godot;

public partial class PlayerHealthBar : HealthBar
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
    }

    private void HandlePlayerHealthChange(float damage)
    {
        MaxValue = Player.Instance.MaxHealth;
        Value = Player.Instance.CurrentHealth;
    }
}
