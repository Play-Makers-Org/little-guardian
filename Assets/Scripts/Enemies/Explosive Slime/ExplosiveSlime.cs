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

    public override void GetDamage(float damage)
    {
        if(_exploding.explodingStatus != ExplosiveEnemyExplodingStatus.EXPLODING)
        {
            base.GetDamage(damage);
        }
    }

    protected override void Die()
    {
        _exploding.Explode();
    }
}