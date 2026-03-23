using Godot;

public partial class CommonScenes : Node
{
    public static CommonScenes Instance { get; private set; }

    [Export]
    public PackedScene Puff { get; set; } // A puff of smoke

    public override void _Ready()
    {
        Instance = this;
    }
}
