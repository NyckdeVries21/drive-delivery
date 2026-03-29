using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Objects")]
    [SerializeField] private GameObject questList;
    [SerializeField] public GameObject completeTaskUI;

    [Header("Game Activity")]
    public bool questActive = false;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        questList.SetActive(true);
    }

    private void Update()
    {
        
    }

    // shop & owned stuff
}
