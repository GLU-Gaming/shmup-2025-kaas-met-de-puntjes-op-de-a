using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;                     // Bullet prefab
    [SerializeField] private float BaseCooldown = 0.5f;                 // base cooldown for shooting
    [SerializeField] private float ShootingCooldown;         // current cooldown for shooting
    public float speed = 6.0f;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");         // get horizontal axis
        float vertical = Input.GetAxis("Vertical");         // get vertical axis

        Vector3 moveVec = new Vector3(horizontal, 0, vertical);         //create new Vector3
        moveVec = moveVec.normalized;

        controller.Move(moveVec * speed * Time.deltaTime);          //beweegt controller

        ShootingCooldown -= Time.deltaTime;
        ShootBullet();
    }

    // Instantiate bullet prefab
    void ShootBullet()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ShootingCooldown <= 0f)
        {
            Debug.Log("het werkt");
            Instantiate(Bullet, transform.position, transform.rotation);
            ShootingCooldown = 0;
            ShootingCooldown += BaseCooldown;
        }
    }
}
