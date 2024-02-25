using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnScript : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag(TagConstants.PlayerTag).GetComponent<Player>();
    }

    public void DamagePlayer()
    {
        player.GetDamage(1f);
    }
}