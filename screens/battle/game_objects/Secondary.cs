using Godot;
using System;

public partial class Secondary : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 250;

	public override void _PhysicsProcess(double delta)
	{
		var velocity = Input.GetVector("secondary_left", "secondary_right", "secondary_up", "secondary_down");
		MoveAndCollide(velocity * Speed * (float)delta);
	}
}
