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

    public void MoveTowardsPlayerAndRetreat(float distance, float retreatDistance)
    {
        var playerDistance = Vector2.Distance(_player.transform.position, _obj.transform.position);

        if (playerDistance > distance)
        {
            _obj.transform.position = Vector2.MoveTowards(_obj.transform.position, _player.transform.position, _moveSpeed * Time.deltaTime);
        }
        else if (playerDistance < retreatDistance)
        {
            _obj.transform.position = Vector2.MoveTowards(_obj.transform.position, _player.transform.position, _moveSpeed * Time.deltaTime * -1);
        }
        else
        {
            Debug.Log("Enemy Stopped !!!");
        }
    }
}