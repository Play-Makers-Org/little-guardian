﻿public static class EnemyConstants
{
    public static readonly float maxHealth = 2f;
    public static readonly float contactDamage = 1f;
    public static readonly float contactAttackCooldown = 0.2f;
    public static readonly float xpGiven = 10f;

    public static readonly float explosiveSlimeMaxHealth = 2f;
    public static readonly float explosiveSlimeContactDamage = contactDamage;
    public static readonly float explosiveSlimeContactAttackCooldown = contactAttackCooldown;
    public static readonly float explosiveSlimeXPGiven = xpGiven;

    public static readonly float slimeMaxHealth = 4f;
    public static readonly float slimeContactDamage = contactDamage;
    public static readonly float slimeContactAttackCooldown = contactAttackCooldown;
    public static readonly float slimeXPGiven = xpGiven;

    public static readonly float rangedSlimeMaxHealth = 2f;
    public static readonly float rangedSlimeContactDamage = contactDamage;
    public static readonly float rangedSlimeContactAttackCooldown = contactAttackCooldown;
    public static readonly float rangedSlimeXPGiven = xpGiven;

    public static EnemyGeneralProperties GetProperties(Enemy enemy)
    {
        var properties = enemy.properties;

        if (enemy is Slime)
        {
            properties.maxHealth = slimeMaxHealth;
            properties.contactDamage = slimeContactDamage;
            properties.contactAttackCooldown = slimeContactAttackCooldown;
            properties.xpGiven = slimeXPGiven;
        }
        else if (enemy is RangedSlime)
        {
            properties.maxHealth = rangedSlimeMaxHealth;
            properties.contactDamage = rangedSlimeContactDamage;
            properties.contactAttackCooldown = rangedSlimeContactAttackCooldown;
            properties.xpGiven = rangedSlimeXPGiven;
        }
        else if (enemy is ExplosiveSlime)
        {
            properties.maxHealth = explosiveSlimeMaxHealth;
            properties.contactDamage = explosiveSlimeContactDamage;
            properties.contactAttackCooldown = explosiveSlimeContactAttackCooldown;
            properties.xpGiven = explosiveSlimeXPGiven;
        }

        return properties;
    }
}