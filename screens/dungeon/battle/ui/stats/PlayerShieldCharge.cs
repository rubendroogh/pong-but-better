using Godot;
using System;

public partial class PlayerShieldCharge : Label
{
    private string Template = "| Shield Ultimate Charge: {0}/10";

    public override void _Ready()
    {
        Text = string.Format(Template, Player.Instance.Shield.ShieldCharge);
        CallDeferred(nameof(ConnectSignals));
    }

    private void ConnectSignals()
    {
        Player.Instance.Shield.ShieldChargeChange += HandleShieldChargeChange;
    }

    private void HandleShieldChargeChange()
    {
        Text = string.Format(Template, Player.Instance.Shield.ShieldCharge);
    }
}
