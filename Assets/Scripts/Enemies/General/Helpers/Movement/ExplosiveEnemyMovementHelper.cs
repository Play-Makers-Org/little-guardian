using UnityEngine;

public class ExplosiveEnemyMovementHelper
{
    private GameObject _obj;

    public ExplosiveEnemyMovementHelper(GameObject obj)
    {
        _obj = obj;
    }

    public void MoveTowardsTarget(Transform target)
    {
        var rb = _obj.GetComponent<Rigidbody2D>();
        var movementProperties = _obj.GetComponent<ExplosiveEnemyMovement>().movementProperties;
        var moveSpeed = movementProperties.moveSpeed;
        var distance = movementProperties.distance;
        var playerDistance = Vector2.Distance(target.position, _obj.transform.position);

        if (playerDistance > distance)
        {
            Vector2 direction = target.position - _obj.transform.position;
            Vector2 directionVelocity = direction.normalized;
            rb.velocity = directionVelocity * moveSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}