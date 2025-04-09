using UnityEngine;

public class BasePickup : MonoBehaviour
{
    protected float TimeAlive = 5f;                                     // Time in seconds before the pickup is destroyed
    protected GameObject player;                                        // Reference to the player object
    protected PlayerController playerScript;                            // Reference to the PlayerController script
    protected GameObject Gamemanager;                                   // Reference to the GameManager object
    protected GameBoss GameBoss;                                        // Reference to the GameBoss script

    protected void Awake()
    {
        player = GameObject.FindWithTag("Player");                       // Find the player object by tag
        playerScript = player.GetComponent<PlayerController>();          // Get the PlayerController component from the player object
        Gamemanager = GameObject.FindWithTag("GameManager");             // Find the GameManager object by tag
        GameBoss = Gamemanager.GetComponent<GameBoss>();                 // Get the GameBoss component from the GameManager object
    }
    void Update()
    {
        TimeAlive -= Time.deltaTime;
        if (TimeAlive <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Activate()
    {
        if(playerScript.Playerhealth < 500)                            // Check if player health is already at max
        {
            playerScript.Playerhealth += 50;                            // Increase player health by 50
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("nice try no overhealth here");                   // Set player health to max
            Destroy(gameObject);
        }

    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Activate();
        }
    }
}
