using Godot;
using System;

public partial class DefaultShield : Shield
{
	public override void _PhysicsProcess(double delta)
	{
		var velocity = Input.GetVector("secondary_left", "secondary_right", "secondary_up", "secondary_down");
		MoveAndCollide(velocity * Speed * (float)delta);
	}

    public override void Special()
    {
        // Wave
    }

    public override void Ultimate()
    {
        // Explosive projectiles
    }
}
