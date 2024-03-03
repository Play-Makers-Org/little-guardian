using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    protected EnemyMovementHelper movementHelper;
    public EnemyMovementProperties movementProperties;

    protected void Awake()
    {
        movementHelper = new EnemyMovementHelper(gameObject);
    }

    protected void Move()
    {
        switch (movementProperties.movementType)
        {
            case EnemyEnums.EnemyMovementTypes.MOVE_TOWARDS_PLAYER:
                movementHelper.MoveTowardsPlayer();
                break;
        }
    }
}