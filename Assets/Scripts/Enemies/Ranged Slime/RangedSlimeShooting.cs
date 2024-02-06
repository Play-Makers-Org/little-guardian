public class RangedSlimeShooting : EnemyShooting
{
    public RangedSlimeShooting()
    {
        this.timeBetweenShots = EnemyConstants.rangedSlimeTimeBetweenShots;
        this.shootingType = EnemyConstants.rangedSlimeShootingType;
    }

    private void Update()
    {
        this.Shoot();
    }
}