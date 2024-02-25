using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerProperties props;

    // Start is called before the first frame update
    private void Start()
    {
        props.health = props.maxHealth;
        var healthBar = transform.Find("HealthBar").gameObject;
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