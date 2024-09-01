using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    public EnemyGeneralProperties properties;
    protected float health;
    protected float lastContactAttackTime;

    public PlayerXPManager xpManager;

    public Enemy()
    {
    }

    private void Start()
    {
        health = properties.maxHealth;
        //xpManager = GameObject.Find(GameObjectNameConstants.bar).GetComponent<PlayerXPManager>();
        xpManager = GameObject.FindGameObjectWithTag(TagConstants.PlayerTag).GetComponent<PlayerXPManager>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        var obj = collision.gameObject;
        if (Time.time - lastContactAttackTime >= properties.contactAttackCooldown)
        {
            Attack(obj);
            lastContactAttackTime = Time.time;
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
        if (gameObject.CompareTag(TagConstants.PlayerTag))
        {
            Player player = gameObject.GetComponent<Player>();
            player.GetDamage(properties.contactDamage);
        }
    }

    public virtual void GetDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
            Die();
    }

    protected virtual void Die()
    {
        xpManager.GainXP(properties.xpGiven);
        Destroy(gameObject);
    }
}