using Godot;

public partial class EnemyHitBox : StaticBody2D
{
	[Export]
	public bool IsCritical { get; set; }

	[Export]
	public Node DamageReceiver { get; set; } // If unset: use the EnemyController

	public void ApplyHit(int damage)
	{
		GD.Print("Hit!");

		if (DamageReceiver is IHittable hittable)
		{
			hittable.Hit(damage, IsCritical);
		}
		else
		{
			var enemyController = BattleController.Instance.EnemyController as IHittable;
			enemyController.Hit(damage, IsCritical);
		}
	}
}
