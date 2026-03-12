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
        if (collisionInfo != null)
        {
            LinearVelocity = LinearVelocity.Bounce(collisionInfo.GetNormal());
        }
    }
}
