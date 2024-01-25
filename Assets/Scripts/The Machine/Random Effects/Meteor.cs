using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] private float _cooldown = 1.5f;
    [SerializeField] private float _damage = 2f;

    [SerializeField] private Animator _animator;

    private RandomPosGenerator _posGenerator = new RandomPosGenerator(4, 4);
    private bool _isAttackFinished = false;
    private float _attackCoolDown = 0.7f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = _posGenerator.Generate();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _cooldown -= Time.deltaTime;
        if (_cooldown <= 0f)
        {
            _animator.SetTrigger("Meteor");
            if (!_isAttackFinished)
                Attack();
            Destroy(gameObject, 1f);
        }
    }

    private void Attack()
    {
        _attackCoolDown -= Time.deltaTime;
        if(_attackCoolDown <= 0f)
        {
            var colliderSize = GetComponent<Collider2D>().bounds.size;
            Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, colliderSize, 0f);
            foreach (var collider in colliders)
            {
                var obj = collider.gameObject;
                if (obj.CompareTag("Player"))
                {
                    Player player = obj.GetComponent<Player>();
                    player.GetDamage(_damage);
                }
                else if (obj.CompareTag("Enemy"))
                {
                    IEnemy enemy = obj.GetComponents<MonoBehaviour>().OfType<IEnemy>().FirstOrDefault();
                    enemy.GetDamage(_damage);
                }
            }
            _isAttackFinished = true;
        }
    }
}
