using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class ShopManagement : MonoBehaviour
{
    [Header("Player")]
    public Inventory playerInventory;

    [Header("Pickup")]
    [SerializeField] private TextMeshProUGUI PickupCostsTxt;
    [SerializeField] private GameObject pickup;

    [Header("LVL2: Roadcar")]
    [SerializeField] private TextMeshProUGUI L2CostsTxt;
    [SerializeField] private GameObject roadcar; 

    [Header("LVL4: Van")]
    [SerializeField] private TextMeshProUGUI l4CostsTxt;
    [SerializeField] private GameObject van;

    [Header("LVL6: Towtruck")]
    [SerializeField] private TextMeshProUGUI l6CostsTxt;
    [SerializeField] private GameObject towtruck;

    [Header("LVL8: Truck")]
    [SerializeField] private TextMeshProUGUI l8CostsTxt;
    [SerializeField] private GameObject truck;

    [Header("LVL10: Van XL")]
    [SerializeField] private TextMeshProUGUI l10CostsTxt;
    [SerializeField] private GameObject vanXL;

    void Start()
    {
        playerInventory = GetComponent<Inventory>();
    }

    public void RoadcarBuy()
    {

    }

    public void VanBuy()
    {

    }

    public void TowTruckBuy()
    {

    }

    public void TruckBuy()
    {

    }

    public void VanXLBuy()
    {

    }
}
