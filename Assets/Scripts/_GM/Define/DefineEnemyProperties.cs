using UnityEngine;

public class DefineEnemyProperties : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject[] rangedEnemies;
    [SerializeField] private GameObject[] explosiveEnemies;

    private void Awake()
    {
        foreach (var enemy in enemies)
        {
            var general = enemy.GetComponent<Enemy>();
            general.properties = EnemyConstants.GetProperties(general);

            var movement = enemy.GetComponent<EnemyMovement>();
            movement.movementProperties = EnemyMovementConstants.GetProperties(movement);
        }

        foreach (var rangedEnemy in rangedEnemies)
        {
            var general = rangedEnemy.GetComponent<Enemy>();
            general.properties = EnemyConstants.GetProperties(general);

            var movement = rangedEnemy.GetComponent<RangedEnemyMovement>();
            movement.properties = RangedEnemyMovementConstants.GetProperties(movement);

            var shooting = rangedEnemy.GetComponent<EnemyShooting>();
            shooting.properties = RangedEnemyShootingConstants.GetProperties(shooting);
        }

        foreach (var explosiveEnemy in explosiveEnemies)
        {
            var general = explosiveEnemy.GetComponent<Enemy>();
            general.properties = EnemyConstants.GetProperties(general);

            var movement = explosiveEnemy.GetComponent<ExplosiveEnemyMovement>();
            movement.movementProperties = ExplosiveEnemyMovementConstants.GetProperties(movement);
        }
    }
}