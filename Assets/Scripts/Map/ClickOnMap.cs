using UnityEngine;

public class ClickOnMap : MonoBehaviour
{
    [SerializeField] private GameObject Map;

    public void ShowMinimap()
    {
        Map.SetActive(false);
    }

    public void ShowMap()
    {
        Map.SetActive(true);
    }
}
