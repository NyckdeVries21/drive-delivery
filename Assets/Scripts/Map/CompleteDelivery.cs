using UnityEngine;

public class CompleteDelivery : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeliverLoc"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("Delivery Completed");
        }
    }
}
