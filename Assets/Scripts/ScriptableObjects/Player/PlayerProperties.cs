using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerProp", menuName = "ScriptableObject/PlayerProperty")]
public class PlayerProperties : ScriptableObject
{
    public float maxHealth;
    public float health;
    public GameObject healthBar;

    public void GetDamage(float damage)
    {
        health -= damage;
        SetHealthBarValue();
    }

    public void SetHealthBar(GameObject obj)
    {
        healthBar = obj;
        var healthBarPos = new Vector3(-0.15f, 0.75f);
        healthBar.transform.localPosition = healthBarPos;
    }

    public void SetHealthBarValue()
    {
        var healthPercent = health / maxHealth;
        var bar = healthBar.transform.Find("Bar").gameObject;
        bar.transform.localScale = new Vector3(healthPercent, 1);
    }
}