using UnityEngine;

public class ExplosiveEnemyMovement : MonoBehaviour
{
    protected ExplosiveEnemyMovementHelper movementHelper;
    public ExplosiveEnemyMovementSO movementProperties;
    public Transform target;

    protected virtual void Awake()
    {
        movementHelper = new ExplosiveEnemyMovementHelper(gameObject);
    }

    protected void MoveTowardsTarget()
    {
        movementHelper.MoveTowardsTarget(target);
    }
}