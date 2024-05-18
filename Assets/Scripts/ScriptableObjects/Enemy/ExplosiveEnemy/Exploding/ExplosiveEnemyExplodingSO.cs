using UnityEngine;

[CreateAssetMenu(fileName = "NewExplosiveEnemyExplodingSO", menuName = "ScriptableObject/ExplosiveEnemy/ExplosiveEnemyExplodingSO")]
public class ExplosiveEnemyExplodingSO : ScriptableObject
{
    public float explosionDamage;
    public float explosionRange;
    public float explosionForce;
    public float waitingTimeBeforeExplosion;

    private void OnEnable()
    {
        explosionDamage = ExplosiveEnemyExplodingConstants.explosionDamage;
        explosionRange = ExplosiveEnemyExplodingConstants.explosionRange;
        explosionForce = ExplosiveEnemyExplodingConstants.explosionForce;
        waitingTimeBeforeExplosion = ExplosiveEnemyExplodingConstants.waitingTimeBeforeExplosion;
    }
}