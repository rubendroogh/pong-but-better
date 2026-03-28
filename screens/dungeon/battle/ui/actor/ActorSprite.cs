using Godot;

public partial class ActorSprite : Control
{
	[Export]
	private bool IsPlayer { get; set; }

	[Export]
	private AnimationPlayer AnimationPlayer { get; set; }
	
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
		actor.ActorCriticalHit += HandleActorDamaged;
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

	private void HandleActorDamaged(float damage)
	{
		AnimationPlayer.Play("tilt");
	}
}
