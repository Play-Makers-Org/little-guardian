using UnityEngine;

[CreateAssetMenu(fileName = "NewGameEventProperty", menuName = "ScriptableObjects/HarmfulGameEventProperty")]
public class HarmfulGameEventProperties : ScriptableObject
{
    public float attackCooldown;
    public float cooldown;
    public float damage;
    public float objectDestructionTime;
    public RandomPosGenerator posGenerator;

    private void OnEnable()
    {
        attackCooldown = HarmfulGameEventConstants.attackCooldown;
        cooldown = HarmfulGameEventConstants.cooldown;
        damage = HarmfulGameEventConstants.damage;
        objectDestructionTime = HarmfulGameEventConstants.objectDestructionTime;
        posGenerator = HarmfulGameEventConstants.posGenerator;
    }
}