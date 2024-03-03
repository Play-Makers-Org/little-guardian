public class RangedSlimeProjectile : EnemyProjectile
{
    public RangedSlimeProjectile()
    {
        this.projectileDamage = RangedEnemyShootingConstants.rangedSlimeProjectileDamage;
        this.projectileSpeed = RangedEnemyShootingConstants.rangedSlimeProjectileSpeed;
    }

    private void Update()
    {
        this.MoveTowardsPlayer();
    }
}