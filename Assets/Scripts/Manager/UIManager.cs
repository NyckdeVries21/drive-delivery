using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("InfoField")]
    [SerializeField] public TextMeshProUGUI playerMoneyAmount;
    [SerializeField] private TextMeshProUGUI dayTime;
    [SerializeField] private TextMeshProUGUI pLevel;

    [Header("Clock Data")]
    private float timer;
    private int minutes = 00;
    private int hours = 8;
    private List<string> dayNames;
    private int week;

    [Header("Settings Tabs")]
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject saveDataMenu;

    [Header("Game Active?")]
    [SerializeField] private GameObject inGameUI;
    

    private void Update()
    {
        timer += Time.deltaTime;
        dayTime.text = hours +  ":0"+ minutes;
        if (minutes >= 10)
        {
            dayTime.text = hours + ":" + minutes;
        }
        CalculateClock();
        PlayerMoneyUpdate();
        ShowLevel();

        if ( GameManager.instance.questActive == false)
        {
            inGameUI.SetActive(false);
        }
        else
        {
            inGameUI.SetActive(true);
        }
    }

    private void CalculateClock()
    {
        if (timer >= 5)
        {
            minutes++;
            timer = 0;
            if (minutes > 60)
            {
                hours++;
                minutes = 0;
                if (hours > 24)
                {
                    // dag erbij
                }
            }
        }
    }

    private void PlayerMoneyUpdate()
    {
        PlayerStats playerStats = FindAnyObjectByType<PlayerStats>();

        playerMoneyAmount.text = "Cash: " + playerStats.moneyAmount;
    }

    private void ShowLevel()
    {
        PlayerStats playerStats = FindAnyObjectByType<PlayerStats>();
        pLevel.text = "" + playerStats.experienceLevel;
    }

    public void SettingTabOpenClose()
    {
        if (!settingsMenu.activeSelf)
        {
            settingsMenu.SetActive(true);
        }
        else { settingsMenu.SetActive(false); }
    }

    public void SaveDataTabOpenClose() // save data tab
    {
        if (!saveDataMenu.activeSelf)
        {
            saveDataMenu.SetActive(true);
        } else {saveDataMenu.SetActive(false); }
    }

}
