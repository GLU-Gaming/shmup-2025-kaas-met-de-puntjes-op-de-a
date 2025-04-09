using UnityEngine;

public class pepperonibullet : MonoBehaviour
{
    [SerializeField] private float TimeAlive = 2f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float MoveSpeed = 1f;
    private GameObject player;
    private PlayerController playerScript;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * -MoveSpeed);
        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
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
            playerScript.Playerhealth -= 50;
            Destroy(gameObject);
        }
    }
}
