public static class HarmfulGameEventConstants
{
    public static readonly float attackCooldown = 0f;
    public static readonly float cooldown = 1f;
    public static readonly float damage = 1f;
    public static readonly float objectDestructionTime = 1f;
    public static readonly RandomPosGenerator posGenerator = new RandomPosGenerator();

    public static readonly float lightningAttackCooldown = attackCooldown;
    public static readonly float lightningCooldown = cooldown;
    public static readonly float lightningDamage = damage;
    public static readonly float lightningObjectDestructionTime = objectDestructionTime - 0.5f;
    public static readonly RandomPosGenerator lightningPosGenerator = new RandomPosGenerator(2, 2);

    public static readonly float meteorAttackCooldown = attackCooldown + 0.7f;
    public static readonly float meteorCooldown = cooldown + 0.5f;
    public static readonly float meteorDamage = damage + 1f;
    public static readonly float meteorObjectDestuctionTime = objectDestructionTime;
    public static readonly RandomPosGenerator meteorPosGenerator = new RandomPosGenerator(4, 4);

    public static HarmfulGameEventProperties GetEventProperties(HarmfulGameEvent gameEvent)
    {
        var properties = gameEvent.properties;
        if (gameEvent is Lightning)
        {
            properties.attackCooldown = HarmfulGameEventConstants.lightningAttackCooldown;
            properties.cooldown = HarmfulGameEventConstants.lightningCooldown;
            properties.damage = HarmfulGameEventConstants.lightningDamage;
            properties.objectDestructionTime = HarmfulGameEventConstants.lightningObjectDestructionTime;
            properties.posGenerator = HarmfulGameEventConstants.lightningPosGenerator;
        }
        else if (gameEvent is Meteor)
        {
            properties.attackCooldown = HarmfulGameEventConstants.meteorAttackCooldown;
            properties.cooldown = HarmfulGameEventConstants.meteorCooldown;
            properties.damage = HarmfulGameEventConstants.meteorDamage;
            properties.objectDestructionTime = HarmfulGameEventConstants.meteorObjectDestuctionTime;
            properties.posGenerator = HarmfulGameEventConstants.meteorPosGenerator;
        }

        return properties;
    }
}