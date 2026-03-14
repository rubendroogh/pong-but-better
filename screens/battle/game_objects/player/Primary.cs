using Godot;

public partial class Primary : CharacterBody2D
{
    [Export]
    public int Speed { get; set; } = 250;

    [Export]
    private PackedScene ProjectileScene { get; set; }

    private Node2D ProjectileSpawnPoint => GetNode<Node2D>("ProjectileSpawn");

    public override void _PhysicsProcess(double delta)
    {
        var velocity = Input.GetVector("primary_left", "primary_right", "primary_up", "primary_down");
        MoveAndCollide(velocity * Speed * (float)delta);
    }

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("primary_shoot"))
        {
            var projectile = ProjectileScene.Instantiate<Projectile>();
            projectile.Position = ProjectileSpawnPoint.GlobalPosition;
            GetParent().AddChild(projectile);
            projectile.Start();
        }
    }
}
