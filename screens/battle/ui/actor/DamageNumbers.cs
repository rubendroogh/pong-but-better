using System;
using System.Threading.Tasks;
using Godot;

public partial class DamageNumbers : Node
{
	// Export: size, 

	[Export]
	private PackedScene DamageNumberScene { get; set; }

	[Export]
	private PackedScene DamageNumberCriticalScene { get; set; }

	private const int MaxXSpawn = 30;

	private const int MinXSpawn = -30;

	private const int MaxYSpawn = 30;

	private const int MinYSpawn = -30;

	public override void _Ready()
	{
		CallDeferred(nameof(ConnectSignals));
	}

	private async Task Test()
	{
		for (int i = 0; i < 150; i++)
		{
			var randomDamage = new Random().Next(60, 110);
			HandleActorDamaged(randomDamage);
			await this.Delay(500);
		}
	}

	private async Task TestCrit()
	{
		for (int i = 0; i < 150; i++)
		{
			var randomDamage = new Random().Next(260, 410);
			HandleActorCriticalDamaged(randomDamage);
			await this.Delay(1500);
		}
	}

	private void ConnectSignals()
	{
		var enemyController = BattleController.Instance?.EnemyController;
		if (enemyController == null)
		{
			GD.Print("EnemyController is null");
			return;
		}

		enemyController.ActorHit += HandleActorDamaged;
		enemyController.ActorCriticalHit += HandleActorCriticalDamaged;
	}

	private void HandleActorDamaged(int damage)
	{
		var numberInstance = DamageNumberScene.Instantiate<TransientDamageNumber>();
		numberInstance.Position = GetRandomSpawnPos();
		numberInstance.Text = damage.ToString();
		AddChild(numberInstance);
	}

	private void HandleActorCriticalDamaged(int damage)
	{
		var numberInstance = DamageNumberCriticalScene.Instantiate<TransientDamageNumber>();
		numberInstance.Position = GetRandomSpawnPos();
		numberInstance.Text = damage.ToString();
		AddChild(numberInstance);
	}

	private Vector2 GetRandomSpawnPos()
	{
		var randomX = new Random().Next(MinXSpawn, MaxXSpawn);
		var randomY = new Random().Next(MinYSpawn, MaxYSpawn);

		return new Vector2(randomX, randomY);
	}
}
