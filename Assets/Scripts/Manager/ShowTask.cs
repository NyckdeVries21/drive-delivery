using TMPro;
using UnityEngine;

public class ShowTask : MonoBehaviour
{
    [Header("Delivery Data")]
    [SerializeField] private TextMeshProUGUI aDeliveryCompany;
    [SerializeField] private TextMeshProUGUI bDeliveryCompany;
    [SerializeField] private TextMeshProUGUI distance;
    [SerializeField] private TextMeshProUGUI productName;
    [SerializeField] private TextMeshProUGUI productAmount;
    [SerializeField] private TextMeshProUGUI rewards;

    [SerializeField] private Challenge testChallenge;

    [SerializeField] private GameObject map;

    private void Start()
    {
        aDeliveryCompany.text = "Start: " + testChallenge.BCompanyname;
        bDeliveryCompany.text = "Deliver at: " + testChallenge.BCompanyname;
        distance.text = testChallenge.Distance + "km";
        productName.text = testChallenge.ProductName;
        productAmount.text = "Amount: " + testChallenge.ProductAmount;
        rewards.text = "Receive: " + testChallenge.Money;
    }

    
}
