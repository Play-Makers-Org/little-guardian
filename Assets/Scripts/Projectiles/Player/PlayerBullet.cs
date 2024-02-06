using System.Linq;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float _damage = 1f;
    [SerializeField] private float _force = 6f;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - transform.position).normalized;
        _rb.velocity = new Vector2(direction.x, direction.y).normalized * _force;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var obj = collision.gameObject;
        if (obj.CompareTag(TagConstants.EnemyTag))
        {
            var enemy = obj.GetComponents<MonoBehaviour>()
                            .OfType<IEnemy>()
                            .FirstOrDefault();
            if (enemy != null)
            {
                enemy.GetDamage(_damage);
                var enemyRb = obj.GetComponent<Rigidbody2D>();
                enemyRb.velocity = Vector2.zero;
            }
        }
        Destroy(gameObject);
    }
}