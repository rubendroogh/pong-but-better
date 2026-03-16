using Godot;

public partial class PlayerHitBox : HitBox
{
    public override void ApplyHit(int damage)
    {
        PlayerController.Instance.Hit(damage, false);
    }
}
