using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;                     // Bullet prefab
    [SerializeField] private GameObject bulletSpawn;
    [SerializeField] private float BaseCooldown = 1f;                 // base cooldown for shooting
    [SerializeField] private float ShootingCooldown;         // current cooldown for shooting
    public float speed = 6.0f;
    private CharacterController controller;

    [SerializeField] public float Playerhealth = 500;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        }

        ShootingCooldown -= Time.deltaTime;
        ShootBullet();
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
