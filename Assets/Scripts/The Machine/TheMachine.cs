using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheMachine : MonoBehaviour
{
    [SerializeField] private float maxHealth = 25f;
    private float health;

    private EffectRandomizer _randomizer;
    public float randomizerCooldown;
    public float minCooldown = 3f;
    public float maxCooldown = 5f;
    // Start is called before the first frame update
    void Start()
    {
        _randomizer = gameObject.GetComponent<EffectRandomizer>();
        health = maxHealth;
        RefreshCoolDown();
    }

    // Update is called once per frame
    void Update()
    {
        randomizerCooldown -= Time.deltaTime;
        if(randomizerCooldown <= 0)
        {
            _randomizer.isRandomizerReady = true;
            RefreshCoolDown() ;
        }
    }

    private void RefreshCoolDown()
    {
        float cooldown = Random.Range(minCooldown, maxCooldown);
        randomizerCooldown = Mathf.Round(cooldown);
    }

    public void GetDamage(float damage)
    {
        health -= damage;
        if(health <= 0 )
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
