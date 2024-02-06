using UnityEngine;

public class EnemyShootingHelper : MonoBehaviour
{
    private readonly GameObject _obj;
    private readonly float _timeBetweenShots;
    private float _nextShootingTime;

    public EnemyShootingHelper(GameObject obj, float timeBetweenShots)
    {
        _obj = obj;
        _timeBetweenShots = timeBetweenShots;
    }

    public void ShootWhenStopped()
    {
        var enemyMovement = _obj.GetComponent<RangedEnemyMovement>();
        var movementStatus = enemyMovement.movementStatus;
        if (movementStatus == EnemyEnums.EnemyMovementStatus.STOPPED)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (Time.time > _nextShootingTime)
        {
            var projectile = _obj.GetComponent<EnemyShooting>().projectile;
            Instantiate(projectile, _obj.transform.position, Quaternion.identity);
            _nextShootingTime = Time.time + _timeBetweenShots;
        }
    }
}