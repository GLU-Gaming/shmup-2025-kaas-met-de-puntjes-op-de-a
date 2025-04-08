using System.Runtime.CompilerServices;
using UnityEngine;

public class PizzaFish : Enemy
{

    [SerializeField] public float damage = 50;
    [SerializeField] private GameObject pepperoni;
    private float damageCooldown;
    [SerializeField] public float shootInterval = 3f;
    [SerializeField] private float shootTimer;

    private void Start()
    {
        shootTimer = shootInterval;
        pointWorth = 100;
        moveSpeed = 200f;
        rb.AddForce(transform.right * moveSpeed);

    }
    void ShootBullet()
    {
        if (shootTimer <= 0)
        {
            Instantiate(pepperoni, transform.position, pepperoni.transform.rotation);
            shootTimer = shootInterval;
        }
    }

    public override void DespawsnOnExit()
    {
        if (transform.position.x <= leftBottom.x - 3)                                                                           // Als de transform van het object aan de linkerkant het scherm verlaat
        {
            base.DespawsnOnExit();
            playerScript.Playerhealth -= damage;
        }
    }

    protected override void Update()
    {
        
        if (GameBoss.gameEnd != true)
        {
            Death();
            damageCooldown -= Time.deltaTime;
            DespawsnOnExit();

            shootTimer -= Time.deltaTime;
            ShootBullet();
            //Debug.Log(playerScript.Playerhealth);
        }

        //if wave 4 is done start boss wave
        base.Update();
    }

    public override void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && damageCooldown <= 0)                                                                                // Als het object de tag "Player" heeft
        {
            playerScript.Playerhealth -= damage;                                                                                                        // doe damage
            damageCooldown = 0;
            damageCooldown += 2f;
        }
        base.OnTriggerEnter(collision);
    }
}
