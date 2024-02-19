using UnityEngine;

public class RandomEnvEffectProperties : ScriptableObject
{
    public float attackCooldown;
    public float cooldown;
    public float damage;
    public float objectDestructionTime;
    public RandomPosGenerator posGenerator;

    private void OnEnable()
    {
        attackCooldown = RandomEnvEffectConstants.attackCooldown;
        cooldown = RandomEnvEffectConstants.cooldown;
        damage = RandomEnvEffectConstants.damage;
        objectDestructionTime = RandomEnvEffectConstants.objectDestructionTime;
        posGenerator = RandomEnvEffectConstants.posGenerator;
    }
}