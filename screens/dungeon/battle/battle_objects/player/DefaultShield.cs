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
		if (ShieldCharge < MaxShieldCharge)
		{
			return;
		}

        // Explosive projectiles
		UltimateActive = true;
		Modulate = Colors.IndianRed;
		
		await this.Delay(5_000);

		UltimateActive = false;
		Modulate = Colors.White;
    }

	public async override Task Hit(Projectile projectile)
	{
		if (UltimateActive)
		{
			projectile.AddModifier(Modifier.Explosive);
		}
		else
		{
			await base.Hit(projectile);
		}
	}
}
