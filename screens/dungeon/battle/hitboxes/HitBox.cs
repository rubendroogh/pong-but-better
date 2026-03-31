using Godot;

public partial class HitBox : StaticBody2D
{
	/// <summary>
	/// Apply the hit to the hitbox using the projectile.
	/// </summary>
	/// <returns>True if the projectile should be destroyed after hit.</returns>
    public virtual bool ApplyHit(Projectile projectile)
	{
		GD.Print("Generic thing hit!");
		return true;
	}
}
