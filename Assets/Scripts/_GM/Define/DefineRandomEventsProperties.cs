using UnityEngine;

public class DefineRandomEventsProperties : MonoBehaviour
{
    public GameObject[] randomEvents;

    private void Awake()
    {
        foreach (var randomEvent in randomEvents)
        {
            RandomEnvEffectProperties properties;
            if (randomEvent.GetComponent<Lightning>() != null)
            {
                properties = randomEvent.GetComponent<Lightning>().properties;
                properties.attackCooldown = RandomEnvEffectConstants.lightningAttackCooldown;
                properties.cooldown = RandomEnvEffectConstants.lightningCooldown;
                properties.damage = RandomEnvEffectConstants.lightningDamage;
                properties.objectDestructionTime = RandomEnvEffectConstants.lightningObjectDestructionTime;
                properties.posGenerator = RandomEnvEffectConstants.lightningPosGenerator;
            }
            else if (randomEvent.GetComponent<Meteor>() != null)
            {
                properties = randomEvent.GetComponent<Meteor>().properties;
                properties.attackCooldown = RandomEnvEffectConstants.meteorAttackCooldown;
                properties.cooldown = RandomEnvEffectConstants.meteorCooldown;
                properties.damage = RandomEnvEffectConstants.meteorDamage;
                properties.objectDestructionTime = RandomEnvEffectConstants.meteorObjectDestuctionTime;
                properties.posGenerator = RandomEnvEffectConstants.meteorPosGenerator;
            }
        }
    }
}