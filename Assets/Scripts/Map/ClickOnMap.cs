using UnityEngine;

public class ClickOnMap : MonoBehaviour
{
    [SerializeField] private GameObject map;

    public void ShowMinimap()
    {
        map.SetActive(false);
    }

    public void ShowMap()
    {
        map.SetActive(true);
    }
}
