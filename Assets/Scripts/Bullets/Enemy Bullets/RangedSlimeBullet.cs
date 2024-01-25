using UnityEngine;

public class RangedSlimeBullet : MonoBehaviour
{
    [SerializeField] private float _damage = 1f;
    [SerializeField] private float _force = 5f;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Vector2 direction = transform.up;
        _rb.velocity = new Vector2(direction.x, direction.y) * _force;
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var obj = collision.gameObject;
        if (obj.CompareTag("Player"))
        {
            var player = obj.GetComponent<Player>();
            player.GetDamage(_damage);
            Destroy(gameObject);
        }
        else if (obj.CompareTag("TheMachine"))
        {
            var theMachine = obj.GetComponent<TheMachine>();
            theMachine.GetDamage(_damage);
            Destroy(gameObject);
        }
    }
}