using UnityEngine;

public class ArmBehavior : MonoBehaviour
{
    private GameObject Player;
    private PlayerController playerController;
    private Rigidbody rb;
    [SerializeField] private float moveSpeed = 500f;
    private Vector3 leftBottom;
    private Vector3 rightTop;
    private float RandomNumber;
    private float TimeAlive = 3f;

    void Start()
    {
        rightTop = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, 20f));                                                  // haalt boven rechtse hoek van het speelveld  
        leftBottom = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 20f));                                                // haalt linker onderste hoek van het speelveld
        Player = GameObject.FindWithTag("Player");
        playerController = Player.GetComponent<PlayerController>();

        rb = gameObject.GetComponent<Rigidbody>();
        RandomNumber = Random.Range(1, 5);
        if (RandomNumber == 1)
        {
            
            rb.position = new Vector3(rightTop.x + 4, 0, leftBottom.z + 2);                                                  // zet de arm op de linker bovenste hoek van het scherm
            rb.AddForce(transform.forward * moveSpeed);                                                                         // beweegt de arm van rechts naar links
        }
        else if (RandomNumber == 2)
        {
            rb.position = new Vector3(leftBottom.x - 4, 0, rightTop.z - 2);                                                  // zet de arm op de linker bovenste hoek van het scherm
            rb.AddForce(transform.forward * -moveSpeed);                                                                        // links naar rechts
        }
        else if (RandomNumber == 3)
        {
            rb.position = new Vector3(leftBottom.x +2, 0, leftBottom.z - 3);                                                    // zet de arm op de linker bovenste hoek van het scherm
            transform.Rotate(90, 90, 90);                                                                                       // draait de arm 90 graden
            rb.AddForce(transform.forward * moveSpeed);                                                                         // beneden naar boven
        }
        else if (RandomNumber == 4)
        {
            rb.position = new Vector3(leftBottom.x +2, 0, rightTop.z + 3);                                                    // zet de arm op de linker bovenste hoek van het scherm
            transform.Rotate(90, 90, 90);                                                                                       // draait de arm 90 graden
            rb.AddForce(transform.forward * -moveSpeed);                                                                             // boven naar beneden
        }
        Debug.Log(RandomNumber);
    }

    void Update()
    {
        TimeAlive -= Time.deltaTime;
        if (TimeAlive <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerController.Playerhealth -= 100;
        }
    }
}
