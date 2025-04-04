using UnityEngine;

public class bossProjectile : MonoBehaviour
{
    private GameObject Player;
    private PlayerController playerController;
    private Rigidbody rb;
    [SerializeField] private float moveSpeed = 10f;
    private Vector3 leftBottom;

    void Start()
    {
        leftBottom = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 20f));                                                // haalt linker onderste hoek van het speelveld
        Player = GameObject.FindWithTag("Player");
        playerController = Player.GetComponent<PlayerController>();

        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * - moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        DespawsnOnExit();
    }

    public virtual void DespawsnOnExit()
    {
        if (rb.position.x <= leftBottom.x - 3)                                                                                  // Als de transform van het object aan de linkerkant het scherm verlaat
        {
            Destroy(gameObject);                                                                                                // verwijder het object
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerController.Playerhealth -= 100;
            Destroy(gameObject);
        }
    }
}

