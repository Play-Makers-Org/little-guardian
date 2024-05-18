using UnityEngine;

public class ExplosiveSlimeExploding : MonoBehaviour
{
    public ExplosiveEnemyExplodingSO explodingProperties;
    private float explosionTime;

    private ExplosiveEnemyExplodingStatus explodingStatus = ExplosiveEnemyExplodingStatus.NORMAL;

    private void Start()
    {
        var explosionCircle = transform.Find(GameObjectNameConstants.explosionCircle).transform;

        var circleSize = explodingProperties.explosionRange * 2 * (Mathf.Pow(transform.localScale.x, -1));

        explosionCircle.localScale = new Vector3(circleSize, circleSize);
    }

    private void Update()
    {
        if (IsPlayerInDistance() & explodingStatus == ExplosiveEnemyExplodingStatus.NORMAL)
        {
            explosionTime = Time.time + explodingProperties.waitingTimeBeforeExplosion;
            explodingStatus = ExplosiveEnemyExplodingStatus.EXPLODING;
        }

        if (explodingStatus == ExplosiveEnemyExplodingStatus.EXPLODING & Time.time >= explosionTime)
        {
            Explode();
        }
    }

    public void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explodingProperties.explosionRange);

        foreach (Collider2D nearbyObject in colliders)
        {
            Rigidbody2D rb = nearbyObject.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                if (rb.GetComponent<Player>() != null)
                {
                    var player = rb.GetComponent<Player>();
                    player.GetDamage(explodingProperties.explosionDamage);
                }
                else if (rb.GetComponent<Enemy>() != null && rb.gameObject != this.gameObject)
                {
                    var enemy = rb.GetComponent<Enemy>();
                    enemy.GetDamage(explodingProperties.explosionDamage);
                }

                Vector2 direction = (rb.transform.position - transform.position).normalized;
                rb.AddForce(direction * explodingProperties.explosionForce);
            }
        }

        Destroy(gameObject);
    }

    private bool IsPlayerInDistance()
    {
        var movementProperties = gameObject.GetComponent<ExplosiveEnemyMovement>().movementProperties;

        var distance = movementProperties.distance;

        var playerPosition = GameObject.FindGameObjectWithTag(TagConstants.PlayerTag).transform.position;

        var playerDistance = Vector2.Distance(playerPosition, transform.position);

        if (playerDistance <= distance)
        {
            return true;
        }

        return false;
    }
}