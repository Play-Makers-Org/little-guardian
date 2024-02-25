using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerProperties props;

    private void Start()
    {
        var healthBar = transform.Find(GameObjectNameConstants.healthBar).gameObject;
        props.SetHealthBar(healthBar);
    }

    public void GetDamage(float damage)
    {
        props.GetDamage(damage);
        if (props.health <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}