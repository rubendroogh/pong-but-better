using Godot;
using System;

public partial class PlayerMoney : Label
{
    public override void _Ready()
    {
        HandleMoneyChanged();
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

        playerController.MoneyChanged += HandleMoneyChanged;
    }

    private void HandleMoneyChanged()
    {
        Text = $"Money: {Player.Instance.Money}";
    }
}
