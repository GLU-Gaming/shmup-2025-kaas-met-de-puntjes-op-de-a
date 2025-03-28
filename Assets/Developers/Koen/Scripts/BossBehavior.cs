using Unity.Multiplayer.Center.Common;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{   
    private Rigidbody rb;
    private float moveSpeed = 200f;                                     // hoe snel de boss beweegt
    [SerializeField] private GameObject projectile;                     // wat de boss schiet
    [SerializeField] private GameObject projectileSpawn;                // waar de spit projectiles spawnen
    [SerializeField] private GameObject arm;                            // wat de boss swiped
    [SerializeField] private GameObject armSpawn;                       // waar de arm spawned
    private float ChoiceTimer;                                          // hoelang tot de volgende keuze
    [SerializeField] private float BaseChoiceTimer = 2f;                // hoe lang de boss wacht met het kiezen van een actie
    private float swipeorspit;                                          // variabele waarmee de boss kiest tussen swipen of spitten

    [SerializeField] public float bossHealth = 2000f;                                   // hoeveel health de boss heeft

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(transform.up * moveSpeed * 1);
        ChoiceTimer = BaseChoiceTimer;
    }

    
    void Update()
    {
        //movement
        if (transform.position.z >= 8)
        {
            rb.linearVelocity = Vector3.zero;
            rb.AddForce(transform.up * moveSpeed * - 1);
        }
        else if (transform.position.z <= -8)
        {
            rb.linearVelocity = Vector3.zero;
            rb.AddForce(transform.up * moveSpeed * 1);
        }

        //attacks
        ChoiceTimer -= Time.deltaTime;
        if (ChoiceTimer <= 0)
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

    private void SpitMeatball()
    {
        Instantiate (projectile, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
    }

    private void SwipeArm()
    {
        Instantiate(arm, armSpawn.transform.position, armSpawn.transform.rotation);
    }

    void OnTriggerEnter(Collider collission)
    {
        if (collission.gameObject.tag == "Bullet")                                                                              // Als het object de tag "Bullet" heeft
        {
            bossHealth -= 50;
        }
    }

}
