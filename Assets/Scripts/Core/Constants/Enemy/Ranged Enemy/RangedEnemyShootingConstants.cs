public static class RangedEnemyShootingConstants
{
    public static readonly float projectileDamage = 1f;
    public static readonly float projectileSpeed = 5f;
    public static readonly EnemyEnums.EnemyShootingType shootingType = EnemyEnums.EnemyShootingType.SHOOT_WHEN_STOPPED;
    public static readonly float timeBetweenShots = 2f;

    public static readonly float rangedSlimeProjectileDamage = projectileDamage;
    public static readonly float rangedSlimeProjectileSpeed = projectileSpeed;
    public static readonly EnemyEnums.EnemyShootingType rangedSlimeShootingType = EnemyEnums.EnemyShootingType.SHOOT_WHEN_STOPPED;
    public static readonly float rangedSlimeTimeBetweenShots = timeBetweenShots;

    public static RangedEnemyShootingProperties GetProperties(EnemyShooting enemyShooting)
    {
        var properties = enemyShooting.properties;

        if (enemyShooting is RangedSlimeShooting)
        {
            properties.projectileDamage = rangedSlimeProjectileDamage;
            properties.projectileSpeed = rangedSlimeProjectileSpeed;
            properties.shootingType = rangedSlimeShootingType;
            properties.timeBetweenShots = rangedSlimeTimeBetweenShots;
        }

        return properties;
    }
}