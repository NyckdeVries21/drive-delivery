using UnityEngine;
using UnityEngine.SceneManagement;

public class Utilities : MonoBehaviour
{
    public void GoToGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GoToStartScreen()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
