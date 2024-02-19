using System.Linq;
using UnityEngine;

public class RandomEnvEffect : MonoBehaviour
{
    protected RandomEnvEffectProperties properties;
    protected Animator animator;
    protected bool isAttackFinished = false;

    public RandomEnvEffect()
    {
        properties = new RandomEnvEffectProperties();
        animator = GetComponent<Animator>();
    }

    protected void HandleAttack()
    {
        properties.cooldown -= Time.deltaTime;
        if (properties.cooldown <= 0f)
        {
            animator.SetTrigger(TriggerConstants.AttackTrigger);
            if (!isAttackFinished)
                Attack();
            Destroy(gameObject, properties.objectDestructionTime);
        }
    }

    private void Attack()
    {
        properties.attackCooldown -= Time.deltaTime;
        if (properties.attackCooldown <= 0f)
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