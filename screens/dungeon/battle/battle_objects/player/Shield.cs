using Godot;
using System.Threading.Tasks;

public partial class Shield : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 250;

    [Export]
    public int SpecialCooldownSeconds { get; set; } = 2;

    [Export]
    public int UltimateCooldownSeconds { get; set; } = 60;

	public override void _PhysicsProcess(double delta)
	{
		var velocity = Input.GetVector("secondary_left", "secondary_right", "secondary_up", "secondary_down");
		MoveAndCollide(velocity * Speed * (float)delta);

        if (Input.IsActionPressed("special"))
        {
            _ = Special();
        }
        else if (Input.IsActionPressed("ultimate"))
        {
            _ = Ultimate();
        }
	}

    // A unique ability that can be activated by button press
    public async virtual Task Special()
    {
        
    }

    // A powerful ability that can be activated by button press
    public async virtual Task Ultimate()
    {
        
    }

    /// <summary>
    /// Used for changing the projectile that hits this shield.
    /// This is done BY REFERENCE!
    /// </summary>
    public async virtual Task Hit(Projectile projectile)
    {
        
    }
}
