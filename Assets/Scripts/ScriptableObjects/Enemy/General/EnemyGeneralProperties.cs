using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyGeneralProperty", menuName = "ScriptableObject/Enemy/EnemyGeneralProperty")]
public class EnemyGeneralProperties : ScriptableObject
{
    public float maxHealth = 2f;

    public float contactDamage = 1f;
    public float contactAttackCooldown = 0.2f;

    private void OnEnable()
    {
        maxHealth = EnemyConstants.maxHealth;
        contactDamage = EnemyConstants.contactDamage;
        contactAttackCooldown = EnemyConstants.contactAttackCooldown;
    }
}