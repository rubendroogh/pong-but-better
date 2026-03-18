using Godot;

public partial class EnemyController : ActorController, IHittable, IActor
{
    public int ActorID { get; set; } = 1;

    public override void _Ready()
    {
        base._Ready();
    }

    public void Hit(int damage, bool critical)
    {
        if (critical)
        {
            CurrentHealth -= damage * 2;
            EmitSignal(SignalName.ActorCriticalHit, ActorID, damage * 2);
        }
        else
        {
            CurrentHealth -= damage;
            EmitSignal(SignalName.ActorHit, ActorID, damage);
        }
    }
}
