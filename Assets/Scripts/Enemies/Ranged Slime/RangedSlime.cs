using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedSlime : MonoBehaviour, IEnemy
{
    [SerializeField] private float _maxHealth = 2f;
    private float _health;

    [SerializeField] private float _damage = 1f;
    private float _attackCoolDown = 1f;
    private float _lastAttackTime;
    void Start()
    {
        _health = _maxHealth;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        var obj = collision.gameObject;
        if (Time.time - _lastAttackTime >= _attackCoolDown)
        {
            Attack(obj);
            _lastAttackTime = Time.time;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
        }
    }

    public void Attack(GameObject gameObject)
    {
        if (gameObject.CompareTag("Player"))
        {
            Player player = gameObject.GetComponent<Player>();
            player.GetDamage(_damage);
        }
    }

    public void GetDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
            Die();
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
