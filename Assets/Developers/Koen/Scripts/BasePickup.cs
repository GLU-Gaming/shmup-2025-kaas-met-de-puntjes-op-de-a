using UnityEngine;

public abstract class BasePickup : MonoBehaviour
{
    protected float TimeAlive = 5f;                                     // Time in seconds before the pickup is destroyed
    protected GameObject player;                                          // Reference to the player object
    protected PlayerController playerScript;                                 // Reference to the PlayerController script
    protected GameObject Gamemanager;                                    // Reference to the GameManager object
    protected GameBoss GameBoss;                                        // Reference to the GameBoss script

    protected void Awake()
    {
        player = GameObject.FindWithTag("Player");                       // Find the player object by tag
        playerScript = player.GetComponent<PlayerController>();           // Get the PlayerController component from the player object
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
    public virtual void Activate()
    {
        Destroy(gameObject);
    }
}
