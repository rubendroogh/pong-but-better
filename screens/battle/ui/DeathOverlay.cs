using Godot;

public partial class DeathOverlay : PanelContainer
{
    [Export]
    private Button Button { get; set; }

    public override void _Ready()
    {
        CallDeferred(nameof(ConnectSignals));
        Visible = false;
    }

    private void ConnectSignals()
    {
        PlayerController.Instance.PlayerDeath += HandlePlayerDeath;
        Button.Pressed += HandleClickRestart;
    }
    
    private void HandlePlayerDeath()
    {
        Visible = true;
    }

    private void HandleClickRestart()
    {
        GetTree().ChangeSceneToFile("res://screens/main_menu/main_menu.tscn");
    }
}
