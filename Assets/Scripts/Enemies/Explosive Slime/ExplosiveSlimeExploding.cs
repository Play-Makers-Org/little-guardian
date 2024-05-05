using UnityEngine;

public class ExplosiveSlimeExploding : MonoBehaviour
{
    private enum ExplosiveEnemyExplodingStatus
    {
        NORMAL,
        EXPLODING
    }

    private float explosionDamage = 2f;
    private float explosionRange = 2f;
    private float explosionForce = 500f;
    private float waitingTimeBeforeExplosion = 0.5f;
    private float explosionTime;

    private ExplosiveEnemyExplodingStatus explodingStatus;

    private void Start()
    {
        var explosionCircle = transform.Find(GameObjectNameConstants.explosionCircle).transform;

        var circleSize = explosionRange * 2 * (Mathf.Pow(transform.localScale.x, -1));

        explosionCircle.localScale = new Vector3(circleSize, circleSize);
    }

    private void Update()
    {
        if (IsPlayerInDistance() & explodingStatus == ExplosiveEnemyExplodingStatus.NORMAL)
        {
            explosionTime = Time.time + waitingTimeBeforeExplosion;
            explodingStatus = ExplosiveEnemyExplodingStatus.EXPLODING;
        }

        if (explodingStatus == ExplosiveEnemyExplodingStatus.EXPLODING & Time.time >= explosionTime)
        {
            Explode();
        }
    }

    public void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRange);

        foreach (Collider2D nearbyObject in colliders)
        {
            Rigidbody2D rb = nearbyObject.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                if (rb.GetComponent<Player>() != null)
                {
                    var player = rb.GetComponent<Player>();
                    player.GetDamage(explosionDamage);
                }
                else if (rb.GetComponent<Enemy>() != null)
                {
                    var enemy = rb.GetComponent<Enemy>();
                    enemy.GetDamage(explosionDamage);
                }

                Vector2 direction = (rb.transform.position - transform.position).normalized;
                rb.AddForce(direction * explosionForce);
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