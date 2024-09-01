using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyGeneralProperty", menuName = "ScriptableObject/Enemy/EnemyGeneralProperty")]
public class EnemyGeneralProperties : ScriptableObject
{
    public float maxHealth;

    public float contactDamage;
    public float contactAttackCooldown;

    public float xpGiven;

    private void OnEnable()
    {
        maxHealth = EnemyConstants.maxHealth;
        contactDamage = EnemyConstants.contactDamage;
        contactAttackCooldown = EnemyConstants.contactAttackCooldown;
        xpGiven = EnemyConstants.xpGiven;
    }

    public void IncreaseHealth(float increaseNumber)
    {
        maxHealth += increaseNumber;
    }
}