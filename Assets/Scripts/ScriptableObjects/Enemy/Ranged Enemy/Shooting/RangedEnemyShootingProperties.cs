using UnityEngine;

[CreateAssetMenu(fileName = "NewRangedEnemyShootingProperty", menuName = "ScriptableObject/RangedEnemy/RangedEnemyShootingProperty")]
public class RangedEnemyShootingProperties : ScriptableObject
{
    public GameObject projectile;
    public float projectileDamage;
    public float projectileSpeed;
    public EnemyEnums.EnemyShootingType shootingType;
    public float timeBetweenShots;

    private void OnEnable()
    {
        projectileDamage = RangedEnemyShootingConstants.projectileDamage;
        projectileSpeed = RangedEnemyShootingConstants.projectileSpeed;
        shootingType = RangedEnemyShootingConstants.shootingType;
        timeBetweenShots = RangedEnemyShootingConstants.timeBetweenShots;
    }
}