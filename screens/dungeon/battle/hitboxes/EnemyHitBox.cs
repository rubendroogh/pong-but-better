using Godot;

public partial class EnemyHitBox : HitBox
{
	[Export]
	public bool IsCritical { get; set; }

	[Export]
	public bool IsArmour { get; set; } // Armour can only be damaged by explosive projectiles

	[Export]
	public Actor DamageReceiver { get; set; } // If unset: use the EnemyController

	public override bool ApplyHit(Projectile projectile)
	{
		if (IsArmour && !projectile.Modifiers.Contains(Modifier.Explosive))
		{
			return false;
		}

		if (DamageReceiver is IHittable hittable)
		{
			hittable.Hit(projectile.Damage, IsCritical);
		}
		else
		{
			BattleController.Instance.EnemyController.Hit(projectile.Damage, IsCritical);
		}

		return true;
	}
}
