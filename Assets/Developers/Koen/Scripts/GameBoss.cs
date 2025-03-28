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
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<PlayerController>();
        Boss = GameObject.FindWithTag("Boss");
        BossScript = Boss.GetComponent<BossBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        healthImage.fillAmount = playerScript.Playerhealth / 500;
        bossHealthImage.fillAmount = BossScript.bossHealth / 2000;
    }
}
