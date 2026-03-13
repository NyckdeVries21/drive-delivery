using TMPro;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [Header("Linked Objects")]
    public GameObject player;
    private PlayerStats playerStats;
    [SerializeField] public JSONManager jsonManager;
    [SerializeField] private GameObject map;
    [SerializeField] private GameObject questionList;

    [Header("Delivery Data")]
    [SerializeField] private TextMeshProUGUI deliveryCompany;
    [SerializeField] private TextMeshProUGUI rewards;

    public Challenge selectedChallenge;

    [Header("Teleport")]
    [SerializeField] private Transform teleportALoc;

    [Header("Complete Task UI")]
    [SerializeField] private TextMeshProUGUI geldTxt;
    [SerializeField] private TextMeshProUGUI dLocTxt; // deliver location
    [SerializeField] private TextMeshProUGUI timeTxt;

    [SerializeField] private TextMeshProUGUI pXPLevel;
    [SerializeField] private TextMeshProUGUI pExperience;

    [Header("Checks")]
    private bool collectedRewards;
    private void Start()
    {
        player = GameObject.Find("Player");
        playerStats = player.GetComponent<PlayerStats>();

        if (selectedChallenge != null)
        {
            deliveryCompany.text = "To: " + selectedChallenge.BCompanyname;
            rewards.text = "Receive: " + selectedChallenge.Money + "    XP: " + selectedChallenge.XP;
        }
    }

    private void Update()
    {
        if (GameManager.instance.completeTaskUI.activeSelf)
        {
            CompletedTaskInfo();
            jsonManager.SaveData();
        }

    }

    public void SelectedTask(Challenge challenge)
    {
        questionList.SetActive(false);
        Time.timeScale = 1f;

        selectedChallenge = challenge;

        UpdateTaskUI();

        if (player != null && teleportALoc != null)
        {
            player.transform.position = teleportALoc.position;
        }
    }

    private void UpdateTaskUI()
    {
        deliveryCompany.text = "To: " + selectedChallenge.BCompanyname;
        rewards.text = "Receive: " + selectedChallenge.Money + '\n' + "XP: " + selectedChallenge.XP;
    }
    
    private void CompletedTaskInfo()
    {
        if ( collectedRewards == false)
        {
            playerStats.experience += int.Parse(selectedChallenge.XP);
            playerStats.moneyAmount += int.Parse(selectedChallenge.Money);
            collectedRewards = true;
        }
        

        playerStats.LevelUpSystem();
        geldTxt.text = selectedChallenge.Money;
        dLocTxt.text = selectedChallenge.BCompanyname;
        // timeTxt.text = uiManager.deliverDuration;

        pXPLevel.text = "" + playerStats.experienceLevel;
        pExperience.text = playerStats.experience + "/" + playerStats.xpToLevelUp;
    }

    public void CloseContinueOn() // nadat je de challenge heb complete
    {
        GameManager.instance.completeTaskUI.SetActive(false);
        questionList.SetActive(true);
        collectedRewards = false;
    }
}
