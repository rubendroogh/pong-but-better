using Godot;
using System;

public partial class HitBox : StaticBody2D
{
    public virtual void ApplyHit(int damage)
	{
		GD.Print("Player hit!");
	}
}
