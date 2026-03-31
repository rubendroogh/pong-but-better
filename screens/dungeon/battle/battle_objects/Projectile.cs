using System.Collections.Generic;
using Godot;

public partial class Projectile : CharacterBody2D
{
    public List<Modifier> Modifiers { get; set; } = [];

    public int Damage { get; set; } = 10;

    [Export]
    private Vector2 StartingVelocity = new Vector2(500, 0);

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
            var shouldDestroy = targetHitbox.ApplyHit(this);
            if (shouldDestroy)
            {
                QueueFree();
                return;
            }
        }
        else if (collider is Projectile otherProjectile)
        {
            SpawnPuff();
            otherProjectile.QueueFree();
            QueueFree();
            return;
        }

        Velocity = Velocity.Bounce(collisionInfo.GetNormal());
    }

    public void AddModifier(Modifier modifier)
    {
        Modifiers.Add(modifier);
    }

    // Spawns a puff of smoke
    private void SpawnPuff()
    {
        var puff = CommonScenes.Instance.Puff.Instantiate<Node2D>();
        puff.Position = Position;
        AddSibling(puff);
    }
}

public enum Modifier
{
    Explosive, // Explosive projectiles deal damage when hitting armour
}