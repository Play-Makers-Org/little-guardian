using UnityEngine;

public class RangedEnemyMovement : MonoBehaviour
{
    protected EnemyEnums.RangedEnemyMovementType movementType = EnemyEnums.RangedEnemyMovementType.MOVE_TOWARDS_PLAYER_AND_RETREAT;
    protected float moveSpeed;
    protected float distance;
    protected float retreatDistance;
    protected RangedEnemyMovementHelper movementHelper;
    public EnemyEnums.EnemyMovementStatus movementStatus;

    public RangedEnemyMovement()
    {
        moveSpeed = EnemyConstants.enemyMoveSpeed;
        distance = EnemyConstants.enemyDistance;
        retreatDistance = EnemyConstants.enemyRetreatDistance;
        movementStatus = EnemyEnums.EnemyMovementStatus.STOPPED;
    }

    protected void Awake()
    {
        movementHelper = new RangedEnemyMovementHelper(this.gameObject, moveSpeed, distance, retreatDistance);
    }

    protected void Move()
    {
        switch (movementType)
        {
            case EnemyEnums.RangedEnemyMovementType.MOVE_TOWARDS_PLAYER_AND_STOP:
                movementHelper.MoveTowardsPlayerAndStop();
                break;

            case EnemyEnums.RangedEnemyMovementType.MOVE_TOWARDS_PLAYER_AND_RETREAT:
                movementHelper.MoveTowardsPlayerAndRetreat();
                break;
        }
    }
}