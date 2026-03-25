using Godot;

public partial class ActorOwned : Node
{
    // Connect signals to get destroyed when its owner gets destroyed
    public Actor OwnerActor { get; set; }

    public override void _Ready()
    {
        // Get ancestor actor
        OwnerActor = GetParent<Actor>();
        if (Owner == null)
        {
            GD.PrintErr("OwnerActor is null!");
        }

        base._Ready();
    }
}
