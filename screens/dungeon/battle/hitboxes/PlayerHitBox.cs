public partial class PlayerHitBox : HitBox
{
    public override void ApplyHit(int damage)
    {
        Player.Instance.Hit(damage, false);
    }
}
