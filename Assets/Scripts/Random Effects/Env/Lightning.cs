public class Lightning : RandomEnvEffect
{
    private void Awake()
    {
        properties.attackCooldown = RandomEnvEffectConstants.lightningAttackCooldown;
        properties.cooldown = RandomEnvEffectConstants.lightningCooldown;
        properties.damage = RandomEnvEffectConstants.lightningDamage;
        properties.objectDestructionTime = RandomEnvEffectConstants.lightningObjectDestructionTime;
        properties.posGenerator = RandomEnvEffectConstants.lightningPosGenerator;
    }

    private void Update()
    {
        this.HandleAttack();
    }
}