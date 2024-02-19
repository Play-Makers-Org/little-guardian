public class Meteor : RandomEnvEffect
{
    private void Awake()
    {
        properties.attackCooldown = RandomEnvEffectConstants.meteorAttackCooldown;
        properties.cooldown = RandomEnvEffectConstants.meteorCooldown;
        properties.damage = RandomEnvEffectConstants.meteorDamage;
        properties.objectDestructionTime = RandomEnvEffectConstants.meteorObjectDestuctionTime;
        properties.posGenerator = RandomEnvEffectConstants.meteorPosGenerator;
    }

    private void Update()
    {
        this.HandleAttack();
    }
}