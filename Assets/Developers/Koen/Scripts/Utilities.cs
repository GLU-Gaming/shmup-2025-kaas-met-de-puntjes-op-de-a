using UnityEngine.SceneManagement;
using UnityEngine;
public class Utilities : MonoBehaviour
{   
    public void StartGame()
    {
        SceneManager.LoadScene("storymode");
    }

    public void SettingsMenu()
    {
        SceneManager.LoadScene("howtoplay");
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene("start");
    }
}
