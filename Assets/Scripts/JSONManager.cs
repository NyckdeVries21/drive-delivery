using System.IO;
using UnityEditor;
using UnityEngine;

[System.Serializable]

public class JSONManager : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    private string filePath;

    private void Start()
    {   
        filePath = Path.Combine(Application.persistentDataPath, "UserData");
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(playerStats, true);
        File.WriteAllText(filePath, json);
        Debug.Log("Data Saved" + json);
    }

    public void LoadData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            JsonUtility.FromJsonOverwrite(json, playerStats);
            Debug.Log("Laad de shit");
        }
    }

    public void ResetData()
    {
        PlayerStats resetData = new PlayerStats();
        resetData.moneyAmount = 0;
        resetData.experience = 0;
        resetData.experienceLevel = 1;
        resetData.tasksCompleted = 0;

        if(File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
}
