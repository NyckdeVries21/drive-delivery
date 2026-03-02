using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("InfoField")]
    [SerializeField] private TextMeshProUGUI playerMoneyAmount;
    [SerializeField] private TextMeshProUGUI dayTime;

    [Header("Clock Data")]
    private float timer;
    private int minutes = 00;
    private int hours = 8;
    private List<string> dayNames;
    private int week;

    private void Update()
    {
        timer += Time.deltaTime;
        dayTime.text = hours +  ":0"+ minutes;
        if (minutes >= 10)
        {
            dayTime.text = hours + ":" + minutes;
        }
        CalculateClock();
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

}
