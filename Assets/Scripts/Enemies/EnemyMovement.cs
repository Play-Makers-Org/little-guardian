using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    protected EnemyEnums.EnemyMovementTypes movementType = EnemyEnums.EnemyMovementTypes.MOVE_TOWARDS_PLAYER;
    protected float moveSpeed;
    protected EnemyMovementHelper movementHelper;

    public EnemyMovement()
    {
        moveSpeed = EnemyConstants.enemyMoveSpeed;
    }

    protected void Awake()
    {
        movementHelper = new EnemyMovementHelper(this.gameObject, moveSpeed);
    }

    protected void Move()
    {
        switch (movementType)
        {
            case EnemyEnums.EnemyMovementTypes.MOVE_TOWARDS_PLAYER:
                movementHelper.MoveTowardsPlayer();
                break;
        }
    }
}