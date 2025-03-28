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
            
            transform.position = new Vector3(rightTop.x, 0, leftBottom.z + 2);                                                  // zet de arm op de linker bovenste hoek van het scherm
            rb.AddForce(transform.forward * moveSpeed);                                                                         // beweegt de arm van rechts naar links
        }
        else if (RandomNumber == 2)
        {
            transform.position = new Vector3(leftBottom.x, 0, rightTop.z - 2);                                                  // zet de arm op de linker bovenste hoek van het scherm
            rb.AddForce(transform.forward * -moveSpeed);                                                                        // links naar rechts
        }
        else if (RandomNumber == 3)
        {
            transform.position = new Vector3(leftBottom.x, 0, leftBottom.z);                                                    // zet de arm op de linker bovenste hoek van het scherm
            transform.Rotate(90, 90, 90);                                                                                       // draait de arm 90 graden
            rb.AddForce(transform.forward * moveSpeed);                                                                         // beneden naar boven
        }
        else if (RandomNumber == 4)
        {
            transform.position = new Vector3(leftBottom.x, 0, rightTop.z);                                                    // zet de arm op de linker bovenste hoek van het scherm
            transform.Rotate(90, -90, 90);                                                                                       // draait de arm 90 graden
            rb.AddForce(transform.up * -moveSpeed);                                                                             // boven naar beneden
        }
        Debug.Log(RandomNumber);
    }

    void Update()
    {
       //if(transform.position.x <= leftBottom.x - 3 || transform.position.x >= rightTop.x + 3)
       // {
       //     Destroy(gameObject);
       // }
    }
}
