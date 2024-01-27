using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    protected EnemyEnums.EnemyMovementTypes movementType = EnemyEnums.EnemyMovementTypes.MOVE_TOWARDS_PLAYER;
    protected float moveSpeed;

    public EnemyMovement()
    {
        moveSpeed = EnemyConstants.enemyMoveSpeed;
    }

    protected void Move()
    {
        switch (movementType)
        {
            case EnemyEnums.EnemyMovementTypes.MOVE_TOWARDS_PLAYER:
                EnemyMovementHelper.MoveTowardsPlayer(this.gameObject, moveSpeed);
                break;
        }
    }
}