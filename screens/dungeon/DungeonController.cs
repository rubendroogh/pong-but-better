using Godot;

public partial class DungeonController : Node
{
    public static DungeonController Instance { get; set; }

    public override void _Ready()
    {
        Instance = this;
    }

    // Starts a new dungeon run
    public void StartRun()
    {
        // Go to scene
        GetTree().ChangeSceneToFile("res://screens/dungeon/dungeon_screen.tscn");
    }

    // Ends the current dungeon run
    public void EndRun()
    {
        // Reset player
        // Go to the main menu
    }
}
