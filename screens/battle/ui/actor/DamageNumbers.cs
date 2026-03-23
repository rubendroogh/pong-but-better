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

	[Export]
	private int Radius { get; set; } = 30;

	[Export]
	private bool IsPlayer { get; set; }

	public override void _Ready()
	{
		CallDeferred(nameof(ConnectSignals));
	}

	private void ConnectSignals()
	{
		var actor = GetActor();
		if (actor == null)
		{
			GD.Print("Actor is null");
			return;
		}

		actor.ActorHit += HandleActorDamaged;
		actor.ActorCriticalHit += HandleActorCriticalDamaged;
	}

	private Actor GetActor()
	{
		if (IsPlayer)
		{
			return Player.Instance;
		}
		else
		{
			return BattleController.Instance?.EnemyController;
		}
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
		var randomX = new Random().Next(-Radius, Radius);
		var randomY = new Random().Next(-Radius, Radius);

		return new Vector2(randomX, randomY);
	}
}
