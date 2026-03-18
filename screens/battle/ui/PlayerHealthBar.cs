using Godot;

public partial class PlayerHealthBar : HealthBar
{
    public override void _Ready()
    {
        CallDeferred(nameof(ConnectSignals));
    }

    private void ConnectSignals()
    {
        var playerController = PlayerController.Instance;
        if (playerController == null)
        {
            GD.Print("PlayerController is null");
            return;
        }

        playerController.ActorHit += HandlePlayerHealthChange;
    }

    private void HandlePlayerHealthChange(int actorID, int damage)
    {
        MaxValue = PlayerController.Instance.MaxHealth;
        Value = PlayerController.Instance.CurrentHealth;
    }
}
