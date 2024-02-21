using UnityEngine;

public class DefineRandomEventsProperties : MonoBehaviour
{
    public GameObject[] randomEvents;

    private void Awake()
    {
        foreach (var randomEvent in randomEvents)
        {
            HarmfulGameEventProperties properties;
            if (randomEvent.GetComponent<Lightning>() != null)
            {
                properties = randomEvent.GetComponent<Lightning>().properties;
                properties.attackCooldown = HarmfulGameEventConstants.lightningAttackCooldown;
                properties.cooldown = HarmfulGameEventConstants.lightningCooldown;
                properties.damage = HarmfulGameEventConstants.lightningDamage;
                properties.objectDestructionTime = HarmfulGameEventConstants.lightningObjectDestructionTime;
                properties.posGenerator = HarmfulGameEventConstants.lightningPosGenerator;
            }
            else if (randomEvent.GetComponent<Meteor>() != null)
            {
                properties = randomEvent.GetComponent<Meteor>().properties;
                properties.attackCooldown = HarmfulGameEventConstants.meteorAttackCooldown;
                properties.cooldown = HarmfulGameEventConstants.meteorCooldown;
                properties.damage = HarmfulGameEventConstants.meteorDamage;
                properties.objectDestructionTime = HarmfulGameEventConstants.meteorObjectDestuctionTime;
                properties.posGenerator = HarmfulGameEventConstants.meteorPosGenerator;
            }
        }
    }
}