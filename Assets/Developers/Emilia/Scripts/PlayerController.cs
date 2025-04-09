using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;                         // Bullet prefab
    [SerializeField] private GameObject bulletSpawn;
    [SerializeField] private float BaseCooldown = 1f;                   // base cooldown for shooting
    [SerializeField] private float ShootingCooldown;                    // current cooldown for shooting
    public float speed = 6.0f;
    private CharacterController controller;
    public Rigidbody rb;
    [SerializeField] public float Playerhealth = 500;
    private GameObject Gamemanager;
    private GameBoss GameBoss;
    [SerializeField] private GameObject Bubbles1;
    [SerializeField] private GameObject Bubbles2;
    private float BubbleDelay = 1f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        Gamemanager = GameObject.FindWithTag("GameManager");
        GameBoss = Gamemanager.GetComponent<GameBoss>();
    }

    void Update()
    {
        if (GameBoss.gameEnd != true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.position = new Vector3(rb.position.x, rb.position.y, rb.position.z + speed * Time.deltaTime);
                Bubbles1.SetActive(true);
                Bubbles2.SetActive(true);
            }
            else
            {
                BubbleDelay -= Time.deltaTime;
                if (BubbleDelay <= 0)
                {
                    Bubbles1.SetActive(false);
                    Bubbles2.SetActive(false);
                    BubbleDelay = 1f;
                }
            }

            if (Input.GetKey(KeyCode.D))
            {
                rb.position = new Vector3(rb.position.x + speed * Time.deltaTime, rb.position.y, rb.position.z);
            }

            if (Input.GetKey(KeyCode.S))
            {
                rb.position = new Vector3(rb.position.x, rb.position.y, rb.position.z - speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.A))
            {
                rb.position = new Vector3(rb.position.x - speed * Time.deltaTime, rb.position.y, rb.position.z);
            }

            ShootingCooldown -= Time.deltaTime;
            ShootBullet();
        }
    }

    // Instantiate bullet prefab
    void ShootBullet()
    {
        if (Input.GetKey(KeyCode.Space) && ShootingCooldown <= 0)
        {
            Instantiate(Bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            ShootingCooldown = 0;
            ShootingCooldown += BaseCooldown;
        }
    }
}
