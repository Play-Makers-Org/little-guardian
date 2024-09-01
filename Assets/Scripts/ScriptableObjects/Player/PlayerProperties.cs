using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerProp", menuName = "ScriptableObject/PlayerProperty")]
public class PlayerProperties : ScriptableObject
{
    public float currentLevel;
    public float currentXP;
    public float neededXP;

    public float health;
    public GameObject healthBar;
    public float maxHealth;
    

    private void OnEnable()
    {
        maxHealth = PlayerConstants.maxHealth;
        health = maxHealth;
        currentLevel = PlayerConstants.currentLevel;
        currentXP = PlayerConstants.currentXP;
        neededXP = PlayerConstants.neededXP;
    }

    public void GetDamage(float damage)
    {
        health -= damage;
        SetHealthBarValue();
    }

    public void SetHealthBar(GameObject obj)
    {
        healthBar = obj;
        healthBar.transform.localPosition = PlayerConstants.heathBarPos;
    }

    public void SetHealthBarValue()
    {
        var healthPercent = health / maxHealth;
        var bar = healthBar.transform.Find(GameObjectNameConstants.bar).gameObject;
        bar.transform.localScale = new Vector3(healthPercent, 1);
    }
}