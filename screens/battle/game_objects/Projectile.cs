using Godot;
using System;

public partial class Projectile : RigidBody2D
{
    [Export]
    private Vector2 StartingVelocity = new Vector2(500, 0);

    public override void _Ready()
    {
        Start();
    }

    private void Start()
    {
        LinearVelocity = StartingVelocity;
    }

    public override void _PhysicsProcess(double delta)
    {
        var collisionInfo = MoveAndCollide(LinearVelocity * (float)delta);
        if (collisionInfo == null)
        {
            return;
        }

        var collider = collisionInfo.GetCollider() as PhysicsBody2D;

        if (collider.CollisionLayer == 1 << 0) // Bounce (default) layer
        {
            LinearVelocity = LinearVelocity.Bounce(collisionInfo.GetNormal());
        }
        else if (IsLayerSet(collider.CollisionLayer, 8)) // Player hit layer
        {
            GD.Print("Player hit!");
            QueueFree();
        }
        else
        {
            GD.Print("Unknown collision with layer: " + collider.CollisionLayer);
        }
    }

    // TODO: Move this to a utility class if we need it elsewhere
    private static bool IsLayerSet(uint layer, int layerNumber)
    {
        return (layer & (1u << (layerNumber - 1))) != 0;
    }
}
