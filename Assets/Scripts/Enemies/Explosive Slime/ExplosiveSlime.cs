using UnityEngine;

public class ExplosiveSlime : Enemy
{
    private ExplosiveSlimeExploding _exploding;

    private void Start()
    {
        _exploding = GetComponent<ExplosiveSlimeExploding>();
        this.health = this.properties.maxHealth;
    }

    public ExplosiveSlime()
    {
    }

    protected override void Die()
    {
        _exploding.Explode();
    }
}