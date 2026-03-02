using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Info")]
    private int moneyAmount;
    private int experienceLevel;
    private int experience;
    private int tasksCompleted;

    [Header("TextInputs")]
    [SerializeField] private TextMeshProUGUI txtMoneyAmount;
}
