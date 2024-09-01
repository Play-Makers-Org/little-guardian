using UnityEngine;

public class PlayerXPManager : MonoBehaviour
{

    private float xpMultiplier = 0.5f;

    private PlayerXPUI xpBarUI;
    private PlayerProperties playerProps;

    private void Start()
    {
        playerProps = GetComponent<Player>().props;
        xpBarUI = GetComponent<PlayerXPUI>();

        xpBarUI.SetXPBar();
    }

    private void LevelUp(float remainedXP)
    {
        playerProps.currentLevel++;
        playerProps.currentXP = remainedXP;
        playerProps.neededXP += Mathf.Floor(playerProps.neededXP * xpMultiplier);
    }

    public void GainXP(float xp)
    {
        playerProps.currentXP += xp;
        
        while (playerProps.currentXP >= playerProps.neededXP)
        {
            float remainedXP = playerProps.currentXP - playerProps.neededXP;

            LevelUp(remainedXP);
            xpBarUI.SetXPBar();
        }

        xpBarUI.SetXPBar();
    }
}
