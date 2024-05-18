using UnityEngine;

public class EnemyMovementHelper
{
    private static readonly Transform _player = GameObject.FindGameObjectWithTag(TagConstants.PlayerTag).transform;
    private GameObject _obj;

    public EnemyMovementHelper(GameObject obj)
    {
        _obj = obj;
    }

    public void MoveTowardsPlayer()
    {
        var moveSpeed = _obj.GetComponent<EnemyMovement>().movementProperties.moveSpeed;
        var rb = _obj.GetComponent<Rigidbody2D>();
        Vector2 direction = _player.position - _obj.transform.position;
        Vector2 directionVelocity = direction.normalized;
        rb.velocity = directionVelocity * moveSpeed;
    }
}