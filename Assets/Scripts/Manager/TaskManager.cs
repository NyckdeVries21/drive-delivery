using TMPro;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [Header("Linked Objects")]
    public GameObject player;
    [SerializeField] private GameObject map;

    [Header("Delivery Data")]
    [SerializeField] private TextMeshProUGUI deliveryCompany;
    [SerializeField] private TextMeshProUGUI rewards;

    [SerializeField] private Challenge testChallenge;

    [Header("Teleport")]
    [SerializeField] private Transform teleportALoc;
    private void Start()
    {
        player = GameObject.Find("Player");
        deliveryCompany.text = "To: " + testChallenge.BCompanyname;
        rewards.text = "Receive: " + testChallenge.Money;
    }

    public void SelectedTask()
    {
        map.SetActive(false);
        player.transform.position = teleportALoc.transform.position;
    }


}
