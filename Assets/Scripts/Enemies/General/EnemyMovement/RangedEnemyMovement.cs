using UnityEngine;

public class RangedEnemyMovement : MonoBehaviour
{
    protected RangedEnemyMovementHelper movementHelper;

    public EnemyMovementStatus movementStatus;
    public RangedEnemyMovementProperties properties;

    protected void Awake()
    {
        movementHelper = new RangedEnemyMovementHelper(this.gameObject);
        movementStatus = EnemyMovementStatus.STOPPED;
    }

    protected void Move()
    {
        switch (properties.movementType)
        {
            case RangedEnemyMovementType.MOVE_TOWARDS_PLAYER_AND_STOP:
                movementHelper.MoveTowardsPlayerAndStop();
                break;

            case RangedEnemyMovementType.MOVE_TOWARDS_PLAYER_AND_RETREAT:
                movementHelper.MoveTowardsPlayerAndRetreat();
                break;
        }
    }
}