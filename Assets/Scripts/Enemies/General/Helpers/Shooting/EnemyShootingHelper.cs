using UnityEngine;

public class EnemyShootingHelper : MonoBehaviour
{
    private readonly GameObject _obj;
    private float _nextShootingTime;

    public EnemyShootingHelper(GameObject obj)
    {
        _obj = obj;
    }

    public void ShootWhenStopped()
    {
        var enemyMovement = _obj.GetComponent<RangedEnemyMovement>();
        var movementStatus = enemyMovement.movementStatus;
        if (movementStatus == EnemyMovementStatus.STOPPED)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (Time.time > _nextShootingTime)
        {
            var shootingProperties = GetShootingProperties();
            var projectile = shootingProperties.projectile;
            var timeBetweenShots = shootingProperties.timeBetweenShots;

            var projectileComponent = projectile.GetComponent<EnemyProjectile>();
            projectileComponent.projectileDamage = shootingProperties.projectileDamage;
            projectileComponent.projectileSpeed = shootingProperties.projectileSpeed;
            Instantiate(projectile, _obj.transform.position, Quaternion.identity);

            _nextShootingTime = Time.time + timeBetweenShots;
        }
    }

    private RangedEnemyShootingProperties GetShootingProperties()
    {
        return _obj.GetComponent<EnemyShooting>().properties;
    }
}