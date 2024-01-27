using UnityEngine;

public class EnemyMovementHelper
{
    private static readonly Transform _player = GameObject.FindGameObjectWithTag(TagConstants.PlayerTag).transform;

    public static void MoveTowardsPlayer(GameObject obj, float moveSpeed)
    {
        var rb = obj.GetComponent<Rigidbody2D>();
        Vector2 direction = _player.position - obj.transform.position;
        Vector2 directionVelocity = direction.normalized;
        rb.velocity = directionVelocity * moveSpeed;
    }
}