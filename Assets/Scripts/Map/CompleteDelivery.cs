using UnityEngine;

public class CompleteDelivery : MonoBehaviour
{
    [SerializeField] private GameObject completeTaskUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeliverLoc"))
        {
            GameManager.instance.questActive = false;
            other.gameObject.SetActive(false);
            completeTaskUI.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("Delivery Completed");
        }
    }
}
