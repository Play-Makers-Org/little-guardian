using System.Linq;
using UnityEngine;

public class RandomEnvEffect : MonoBehaviour
{
    public RandomEnvEffectProperties properties;
    protected Animator animator;
    protected bool isAttackFinished = false;
    private float _cooldown;
    private float _attackCooldown;

    private void Start()
    {
        animator = GetComponent<Animator>();
        transform.position = properties.posGenerator.Generate();
        _cooldown = properties.cooldown;
        _attackCooldown = properties.attackCooldown;
    }

    protected void HandleAttack()
    {
        _cooldown -= Time.deltaTime;
        if (_cooldown <= 0f)
        {
            animator.SetTrigger(TriggerConstants.AttackTrigger);
            if (!isAttackFinished)
                Attack();
            Destroy(gameObject, properties.objectDestructionTime);
        }
    }

    private void Attack()
    {
        _attackCooldown -= Time.deltaTime;
        if (_attackCooldown <= 0f)
        {
            var colliderSize = GetComponent<Collider2D>().bounds.size;
            Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, colliderSize, 0f);
            foreach (var collider in colliders)
            {
                var obj = collider.gameObject;
                if (obj.CompareTag(TagConstants.PlayerTag))
                {
                    Player player = obj.GetComponent<Player>();
                    player.GetDamage(properties.damage);
                }
                else if (obj.CompareTag(TagConstants.EnemyTag))
                {
                    IEnemy enemy = obj.GetComponents<MonoBehaviour>().OfType<IEnemy>().FirstOrDefault();
                    enemy.GetDamage(properties.damage);
                }
            }
            isAttackFinished = true;
        }
    }
}