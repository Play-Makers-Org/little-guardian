using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyMovementProperty", menuName = "ScriptableObject/Enemy/EnemyMovementProperty")]
public class EnemyMovementProperties : ScriptableObject
{
    public float moveSpeed;
    public EnemyEnums.EnemyMovementTypes movementType;

    private void OnEnable()
    {
        moveSpeed = EnemyMovementConstants.moveSpeed;
        movementType = EnemyMovementConstants.movementType;
    }
}