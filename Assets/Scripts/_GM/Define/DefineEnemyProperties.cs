using UnityEngine;

public class DefineEnemyProperties : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;

    private void Awake()
    {
        foreach (var enemy in enemies)
        {
            var movement = enemy.GetComponent<EnemyMovement>();
            movement.movementProperties = EnemyMovementConstants.GetProperties(movement);
        }
    }
}