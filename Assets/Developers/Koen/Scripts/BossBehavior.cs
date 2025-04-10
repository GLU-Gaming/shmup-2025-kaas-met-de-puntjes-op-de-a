using System.Transactions;
using Unity.Multiplayer.Center.Common;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{   
    private Rigidbody rb;
    private float moveSpeed = 25f;                                     // hoe snel de boss beweegt
    [SerializeField] private GameObject projectile;                     // wat de boss schiet
    [SerializeField] private GameObject projectileSpawn;                // waar de spit projectiles spawnen
    [SerializeField] private GameObject arm;                            // wat de boss swiped
    [SerializeField] private GameObject armSpawn;                       // waar de arm spawned
    private float ChoiceTimer;                                          // hoelang tot de volgende keuze
    [SerializeField] private float BaseChoiceTimer = 2f;                // hoe lang de boss wacht met het kiezen van een actie
    private float swipeorspit;                                          // variabele waarmee de boss kiest tussen swipen of spitten
    public bool ActiveStatus = false;
    [SerializeField] public float bossHealth = 2000f;                                   // hoeveel health de boss heeft
    public bool startedMoving = false;
    private GameObject Player;
    private PlayerController playerController;
    public bool HeDead = false;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        ChoiceTimer = BaseChoiceTimer;
        Player = GameObject.FindWithTag("Player");
        playerController = Player.GetComponent<PlayerController>();
    }

    
    void Update()
    {
        //movement
        if (ActiveStatus == true) 
        {
            StartMoving();
            if (transform.position.z >= 8)
            {
                rb.linearVelocity = Vector3.zero;
                rb.AddForce(transform.up * moveSpeed * -1);
            }
            else if (transform.position.z <= -1.760002 && HeDead == false)
            {
                rb.linearVelocity = Vector3.zero;
                rb.AddForce(transform.up * moveSpeed * 1);
            }

            //enrage mechanic
            if (bossHealth <= 1000)
            {
                BaseChoiceTimer = 1f;
            }


            //attacks
            ChoiceTimer -= Time.deltaTime;
            if (ChoiceTimer <= 0 && HeDead == false)
            {
                ChoiceTimer = 0f;
                ChoiceTimer += BaseChoiceTimer;
                swipeorspit = Random.Range(0, 10);
                if (swipeorspit >= 5)
                {
                    Debug.Log("Swipe");
                    SwipeArm();
                }
                else
                {
                    Debug.Log("Spit");
                    SpitMeatball();
                }
            }
        }
        
    }

    private void SpitMeatball()
    {
        Instantiate (projectile, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
    }

    private void SwipeArm()
    {
        Instantiate(arm, armSpawn.transform.position, armSpawn.transform.rotation);
    }

    private void StartMoving()
    {
        if (startedMoving == false) 
        {
            Debug.Log("started moving");
            gameObject.transform.position = new Vector3(16f, 0, -2f);
            rb.AddForce(transform.up * moveSpeed * 1);
            startedMoving = true;
        }
        
    }
    void OnTriggerEnter(Collider collission)
    {
        if (collission.gameObject.tag == "Bullet" && ActiveStatus == true)                                                                              // Als het object de tag "Bullet" heeft
        {
            bossHealth -= 50;
        }
        else if (collission.gameObject.tag == "Player" && ActiveStatus == true)
        {
            playerController.Playerhealth -= 50;
            playerController.rb.AddForce(Vector3.right * -moveSpeed * 3);
        }
    }

}
