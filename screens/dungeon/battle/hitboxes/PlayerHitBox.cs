public partial class PlayerHitBox : HitBox
{
    public override bool ApplyHit(Projectile projectile)
    {
        Player.Instance.Hit(projectile.Damage, false);
        return true;
    }
}
