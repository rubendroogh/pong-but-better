using Godot;

public partial class Projectile : RigidBody2D
{
    [Export]
    private Vector2 StartingVelocity = new Vector2(500, 0);

    private const int DEFAULT_DAMAGE = 10;

    public void Start(Vector2 velocity = default)
    {
        LinearVelocity = velocity != default ? velocity : StartingVelocity;
    }

    public override void _PhysicsProcess(double delta)
    {
        var collisionInfo = MoveAndCollide(LinearVelocity * (float)delta);
        if (collisionInfo == null)
        {
            return;
        }

        var collider = collisionInfo.GetCollider() as PhysicsBody2D;
        if (collider is EnemyHitBox enemyHitbox)
        {
            enemyHitbox.ApplyHit(DEFAULT_DAMAGE);
            QueueFree();
            return;
        }

        LinearVelocity = LinearVelocity.Bounce(collisionInfo.GetNormal());
    }

    // TODO: Move this to a utility class if we need it elsewhere
    private static bool IsLayerSet(uint layer, int layerNumber)
    {
        return (layer & (1u << (layerNumber - 1))) != 0;
    }
}
