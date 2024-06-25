using UnityEngine;

public class EnemyDifficultyManager : MonoBehaviour
{
    public static readonly float healthIncreaseNumber = 5f;

    private static DefineEnemyProperties defineEnemyProperties;

    private void Start()
    {
        defineEnemyProperties = gameObject.GetComponent<DefineEnemyProperties>();
    }

    public static void IncreaseAllEnemiesMaxHealth()
    {
        foreach (var enemy in defineEnemyProperties.enemies)
        {
            IncreaseEnemyMaxHealth(enemy);
        }

        foreach (var rangedEnemy in defineEnemyProperties.rangedEnemies)
        {
            IncreaseEnemyMaxHealth(rangedEnemy);
        }

        foreach (var explosiveEnemy in defineEnemyProperties.explosiveEnemies)
        {
            IncreaseEnemyMaxHealth(explosiveEnemy);
        }

    }

    private static void IncreaseEnemyMaxHealth(GameObject obj)
    {
        if (obj.CompareTag(TagConstants.EnemyTag))
        {
            var general = obj.GetComponent<Enemy>();
            general.properties.IncreaseHealth(healthIncreaseNumber);
        }
    }
}