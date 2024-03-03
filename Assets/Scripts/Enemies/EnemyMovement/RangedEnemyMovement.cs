using UnityEngine;

public class RangedEnemyMovement : MonoBehaviour
{
    protected RangedEnemyMovementHelper movementHelper;

    public EnemyEnums.EnemyMovementStatus movementStatus;
    public RangedEnemyMovementProperties properties;

    protected void Awake()
    {
        movementHelper = new RangedEnemyMovementHelper(this.gameObject);
        movementStatus = EnemyEnums.EnemyMovementStatus.STOPPED;
    }

    protected void Move()
    {
        switch (properties.movementType)
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