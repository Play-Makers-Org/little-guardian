using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    private EnemyShootingHelper _shootingHelper;
    public RangedEnemyShootingProperties properties;

    private void Awake()
    {
        _shootingHelper = new EnemyShootingHelper(this.gameObject);
    }

    protected void Shoot()
    {
        switch (properties.shootingType)
        {
            case EnemyShootingType.SHOOT_WHEN_STOPPED:
                _shootingHelper.ShootWhenStopped();
                break;
        }
    }
}