using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    protected EnemyEnums.EnemyShootingType shootingType = EnemyEnums.EnemyShootingType.SHOOT_WHEN_STOPPED;
    protected float timeBetweenShots = EnemyConstants.enemyTimeBetweenShots;
    public GameObject projectile;
    private EnemyShootingHelper _shootingHelper;

    private void Awake()
    {
        _shootingHelper = new EnemyShootingHelper(this.gameObject, timeBetweenShots);
    }

    protected void Shoot()
    {
        switch (shootingType)
        {
            case EnemyEnums.EnemyShootingType.SHOOT_WHEN_STOPPED:
                _shootingHelper.ShootWhenStopped();
                break;
        }
    }
}