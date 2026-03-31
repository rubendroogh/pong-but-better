using Godot;
using System.Threading.Tasks;

public partial class DefaultShield : Shield
{
	private bool UltimateActive { get; set; }

    public async override Task Special()
    {
        // Wave
    }

    public async override Task Ultimate()
    {
        // Explosive projectiles
		UltimateActive = true;
		Modulate = Colors.IndianRed;
		
		await this.Delay(5_000);

		UltimateActive = false;
		Modulate = Colors.White;
    }

	public async override Task Hit(Projectile projectile)
	{
		projectile.AddModifier(Modifier.Explosive);
	}
}
