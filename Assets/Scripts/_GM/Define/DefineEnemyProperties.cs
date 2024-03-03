using UnityEngine;

public class DefineEnemyProperties : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject[] rangedEnemies;

    private void Awake()
    {
        foreach (var enemy in enemies)
        {
            var movement = enemy.GetComponent<EnemyMovement>();
            movement.movementProperties = EnemyMovementConstants.GetProperties(movement);
        }

        foreach (var rangedEnemy in rangedEnemies)
        {
            var movement = rangedEnemy.GetComponent<RangedEnemyMovement>();
            movement.properties = RangedEnemyMovementConstants.GetProperties(movement);

            var shooting = rangedEnemy.GetComponent<EnemyShooting>();
            shooting.properties = RangedEnemyShootingConstants.GetProperties(shooting);
        }
    }
}