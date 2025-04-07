using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameBoss : MonoBehaviour
{
    [SerializeField] private Image healthImage;
    [SerializeField] private Image bossHealthImage;
    private GameObject player;
    private PlayerController playerScript;
    private GameObject Boss;
    private BossBehavior BossScript;
    public float CurrentScore = 100;
    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private GameObject DeathPopup;
    public bool gameEnd;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<PlayerController>();
        //Boss = GameObject.FindWithTag("Boss");
        //BossScript = Boss.GetComponent<BossBehavior>();
    }

    void Update()
    {
        healthImage.fillAmount = playerScript.Playerhealth / 500;
        //bossHealthImage.fillAmount = BossScript.bossHealth / 2000;
        ScoreText.text = "Score: <br>" + CurrentScore;

        if (playerScript.Playerhealth < 0)
        {
            gameEnd = true;
            //Time.timeScale = 0;
            DeathPopup.SetActive(true);
        }
        else
        {
            gameEnd = false;
        }
        }
    }
