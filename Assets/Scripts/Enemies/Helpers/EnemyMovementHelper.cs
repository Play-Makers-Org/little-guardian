using UnityEngine;

public class EnemyMovementHelper
{
    private static readonly Transform _player = GameObject.FindGameObjectWithTag(TagConstants.PlayerTag).transform;
    private float _moveSpeed;
    private GameObject _obj;

    public EnemyMovementHelper(GameObject obj, float moveSpeed)
    {
        _moveSpeed = moveSpeed;
        _obj = obj;
    }

    public void MoveTowardsPlayer()
    {
        var rb = _obj.GetComponent<Rigidbody2D>();
        Vector2 direction = _player.position - _obj.transform.position;
        Vector2 directionVelocity = direction.normalized;
        rb.velocity = directionVelocity * _moveSpeed;
    }
}