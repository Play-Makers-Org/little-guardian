using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private Vector3 _playerPosition;
    protected float projectileSpeed = EnemyConstants.enemyProjectileSpeed;
    protected float projectileDamage = EnemyConstants.enemyProjectileDamage;

    private void Start()
    {
        _playerPosition = GameObject.FindGameObjectWithTag(TagConstants.PlayerTag).transform.position;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _playerPosition, projectileSpeed * Time.deltaTime);

        if (transform.position == _playerPosition)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var obj = collision.gameObject;
        if (obj.CompareTag(TagConstants.PlayerTag))
        {
            var player = obj.GetComponent<Player>();
            player.GetDamage(projectileDamage);
            Destroy(gameObject);
        }
    }
}