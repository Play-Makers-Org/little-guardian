using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerXPUI : MonoBehaviour
{
    private TextMeshProUGUI _levelUI;
    private Image _xpBar;
    private PlayerProperties playerProps;

    private void Awake()
    {
        _levelUI = GameObject.Find("PlayerLevel").GetComponent<TextMeshProUGUI>();
        _xpBar = GameObject.Find("XPBar").GetComponent<Image>();
    }

    private void Start()
    {
        playerProps = GetComponent<Player>().props;
        _levelUI.text = "LEVEL : " + playerProps.currentLevel.ToString();
    }

    public void SetXPBar()
    {
        float percantage = playerProps.currentXP / playerProps.neededXP;
        _xpBar.fillAmount = percantage;

        _levelUI.text = "LEVEL : " + playerProps.currentLevel.ToString();
    }
}