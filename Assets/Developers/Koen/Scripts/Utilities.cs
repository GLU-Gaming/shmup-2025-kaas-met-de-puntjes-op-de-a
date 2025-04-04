using UnityEngine.SceneManagement;
using UnityEngine;
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
        GameBoss.gameEnd = false;
        Time.timeScale = 1;
    }

    public void SettingsMenu()
    {
        SceneManager.LoadScene("howtoplay");
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene("start");
        GameBoss.gameEnd = false;
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
