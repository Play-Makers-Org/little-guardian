using UnityEngine;

[CreateAssetMenu(fileName = "NewRangedEnemyMovementProperty", menuName = "ScriptableObject/RangedEnemy/RangedEnemyMovementProperty")]
public class RangedEnemyMovementProperties : ScriptableObject
{
    public float distance;
    public RangedEnemyMovementType movementType;
    public float moveSpeed;
    public float retreatDistance;

    private void OnEnable()
    {
        moveSpeed = RangedEnemyMovementConstants.moveSpeed;
        movementType = RangedEnemyMovementConstants.movementType;
        moveSpeed = RangedEnemyMovementConstants.moveSpeed;
        retreatDistance = RangedEnemyMovementConstants.retreatDistance;
    }
}