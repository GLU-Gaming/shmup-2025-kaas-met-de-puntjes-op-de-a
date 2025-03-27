using UnityEngine;
using UnityEngine.UI;

public class GameBoss : MonoBehaviour
{
    [SerializeField] private Image healthImage;
    private GameObject player;
    private PlayerController playerScript;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        healthImage.fillAmount = playerScript.Playerhealth / 500;
    }
}
