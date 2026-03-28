using Godot;

public partial class EnemyHitBox : HitBox
{
	[Export]
	public bool IsCritical { get; set; }

	[Export]
	public Actor DamageReceiver { get; set; } // If unset: use the EnemyController

	public override void ApplyHit(int damage)
	{
		if (DamageReceiver is IHittable hittable)
		{
			hittable.Hit(damage, IsCritical);
		}
		else
		{
			BattleController.Instance.EnemyController.Hit(damage, IsCritical);
		}
	}
}
