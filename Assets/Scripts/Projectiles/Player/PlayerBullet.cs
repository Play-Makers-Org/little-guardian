using System.Linq;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float _damage = 1f;
    [SerializeField] private float _force = 6f;
    [SerializeField] private float _lifetime = 3f;

    private Rigidbody2D _rb;
    public Vector2 direction;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = new Vector2(direction.x, direction.y).normalized * _force;
    }

    private void Update()
    {
        _lifetime -= Time.deltaTime;
        if( _lifetime <= 0 )
        {
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var obj = collision.gameObject;

        var enemy = obj.GetComponents<MonoBehaviour>()
                        .OfType<IEnemy>()
                        .FirstOrDefault();

        if (enemy != null)
        {
            enemy.GetDamage(_damage);
            var enemyRb = obj.GetComponent<Rigidbody2D>();
            enemyRb.velocity = Vector2.zero;
        }

        Destroy(gameObject);
    }
}