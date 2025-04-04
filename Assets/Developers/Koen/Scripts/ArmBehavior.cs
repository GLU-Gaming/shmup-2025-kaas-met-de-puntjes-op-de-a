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
        RandomNumber = Random.Range(1,5);
        if (RandomNumber == 1)
        {
            
            transform.position = new Vector3(rightTop.x + 4, 0, leftBottom.z + 2);                                                  // zet de arm op de linker bovenste hoek van het scherm
            rb.AddForce(Vector3.right * -moveSpeed);                                                                         // beweegt de arm van rechts naar links
            transform.rotation = Quaternion.Euler(0, 0, -90);

        }
        else if (RandomNumber == 2)
        {
            transform.position = new Vector3(rightTop.x + 2, 0, rightTop.z - 2);                                                  // zet de arm op de linker bovenste hoek van het scherm
            rb.AddForce(Vector3.right * -moveSpeed);                                                                        // links naar rechts
            transform.rotation = Quaternion.Euler(0, 180, -90);
        }
        else if (RandomNumber == 3)
        {
            transform.position = new Vector3(leftBottom.x +2, 0, leftBottom.z - 3);                                                    // zet de arm op de linker bovenste hoek van het scherm
            transform.rotation = Quaternion.Euler(0, 90, -90);                                                                                       // draait de arm 90 graden
            rb.AddForce(Vector3.forward * moveSpeed);                                                                         // beneden naar boven
        }
        else if (RandomNumber == 4)
        {
            transform.position = new Vector3(leftBottom.x +2, 0, rightTop.z + 3);                                                    // zet de arm op de linker bovenste hoek van het scherm
            transform.rotation = Quaternion.Euler(0, 90, -90);                                                                                       // draait de arm 90 graden
            rb.AddForce(Vector3.forward * -moveSpeed);                                                                             // boven naar beneden
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
