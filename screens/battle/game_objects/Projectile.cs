using Godot;

public partial class Projectile : CharacterBody2D
{
    [Export]
    private Vector2 StartingVelocity = new Vector2(500, 0);

    private const int DEFAULT_DAMAGE = 10;

    public void Start(Vector2 velocity = default)
    {
        Velocity = velocity != default ? velocity : StartingVelocity;
    }

    public override void _PhysicsProcess(double delta)
    {
        var collisionInfo = MoveAndCollide(Velocity * (float)delta);
        if (collisionInfo == null)
        {
            return;
        }

        // If the projectile is going too slow, it despawns
        if (Velocity.Length() < 250)
        {
            QueueFree();
        }

        var collider = collisionInfo.GetCollider() as PhysicsBody2D;
        if (collider is HitBox targetHitbox)
        {
            targetHitbox.ApplyHit(DEFAULT_DAMAGE);
            QueueFree();
            return;
        }

        Velocity = Velocity.Bounce(collisionInfo.GetNormal());
    }
}
