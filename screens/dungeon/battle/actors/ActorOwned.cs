using Godot;

/// <summary>
/// ActorOwned nodes are nodes on the battlefield that are connected to a specific actor.
/// They are destroyed when the actor dies.
/// </summary>
public partial class ActorOwned : Node
{
    public Actor OwnerActor { get; set; }

    public override void _Ready()
    {
        OwnerActor = GetParent<Actor>();
        if (Owner == null)
        {
            GD.PrintErr("OwnerActor is null!");
        }

        CallDeferred(nameof(ConnectOnDeathSignals));

        base._Ready();
    }

    private void ConnectOnDeathSignals()
    {
        OwnerActor.ActorDeath += OnDeath;
    }

    protected virtual void OnDeath()
    {
        QueueFree();
    }
}
