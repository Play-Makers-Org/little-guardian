﻿public static class RandomEnvEffectConstants
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
}