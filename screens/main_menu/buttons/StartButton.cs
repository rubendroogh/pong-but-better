using Godot;

public partial class StartButton : Button
{
    public override void _Ready()
    {
        this.Pressed += StartButton_Pressed;
    }

    private void StartButton_Pressed()
    {
        DungeonController.Instance.StartRun();
    }
}
