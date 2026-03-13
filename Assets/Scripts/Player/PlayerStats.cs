using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Header("Info")]
    public int moneyAmount =  0;
    public int experienceLevel = 1;
    public int experience = 0;
    public float xpToLevelUp = 50;
    public float multiplyXPAmount = 1.4f ;
    public int tasksCompleted = 0;

    [Header("Info Inputs")]
    [SerializeField] private TextMeshProUGUI txtMoneyAmount;
    [SerializeField] private Image showXPFill;

    private void Update()
    {
        txtMoneyAmount.text = "" + moneyAmount;
        showXPFill.fillAmount = experience;
    }

    public void LevelUpSystem()
    {
        if (experience >= xpToLevelUp)
        {
            experienceLevel++;
            experience = 0;
            xpToLevelUp *= multiplyXPAmount;
        }
    }

}
