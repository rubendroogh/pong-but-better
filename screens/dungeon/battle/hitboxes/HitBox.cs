using Godot;

public partial class HitBox : StaticBody2D
{
    public virtual void ApplyHit(int damage)
	{
		GD.Print("Generic thing hit!");
	}
}
