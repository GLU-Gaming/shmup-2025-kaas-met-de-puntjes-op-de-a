using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameBoss : MonoBehaviour
{
    [SerializeField] private Image healthImage;
    [SerializeField] private GameObject bosshealthGO;
    [SerializeField] private Image bossHealthImage;
    private GameObject player;
    private PlayerController playerScript;
    private GameObject Boss;
    private BossBehavior BossScript;
    public float CurrentScore = 100;
    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private GameObject DeathPopup;
    [SerializeField] private GameObject WinnerPopup;
    public bool gameEnd;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<PlayerController>();
        Boss = GameObject.FindWithTag("Boss");
        BossScript = Boss.GetComponent<BossBehavior>();
    }

    void Update()
    {
        healthImage.fillAmount = playerScript.Playerhealth / 500;
        ScoreText.text = "Score: <br>" + CurrentScore;

        if (BossScript.ActiveStatus == true)
        {
            bosshealthGO.gameObject.SetActive(true);
            bossHealthImage.fillAmount = BossScript.bossHealth / 2000;
        }
        if (playerScript.Playerhealth < 1)
        {
            gameEnd = true;
            DeathPopup.SetActive(true);
        }
        else if (BossScript.bossHealth < 1)
        {
            gameEnd = true;
            BossScript.HeDead = true;
            WinnerPopup.SetActive(true);
        }
        else
        {
            gameEnd = false;
        }
        }
    }
