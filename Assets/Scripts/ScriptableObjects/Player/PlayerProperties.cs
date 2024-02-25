using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerProp", menuName = "ScriptableObject/PlayerProperty")]
public class PlayerProperties : ScriptableObject
{
    public float maxHealth;
    public float health;
    public GameObject healthBar;

    private void OnEnable()
    {
        maxHealth = PlayerConstants.maxHealth;
        health = maxHealth;
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