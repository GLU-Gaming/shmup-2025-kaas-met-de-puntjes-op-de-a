using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;
public class Utilities : MonoBehaviour
{
    [SerializeField] private GameObject Gamemanager;
    private GameBoss GameBoss;
    private void Start()
    {
        Gamemanager = GameObject.FindWithTag("GameManager");
        GameBoss = Gamemanager.GetComponent<GameBoss>();
    }
    

    public void StartGame()
    {
        SceneManager.LoadScene("storymode");
        if (Gamemanager != null)
        {
            GameBoss.gameEnd = false;

        }
        Time.timeScale = 1;
    }

    public void SettingsMenu()
    {
        SceneManager.LoadScene("howtoplay", LoadSceneMode.Additive);
    }
    public void CloseSettings()
    {
        SceneManager.UnloadSceneAsync("howtoplay");
    }

    public void ReturnToMain()
    {
        if (Gamemanager != null)
        {
            GameBoss.gameEnd = false;
        }
        SceneManager.LoadScene ("start");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
