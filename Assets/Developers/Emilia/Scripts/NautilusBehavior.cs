using Unity.Mathematics;
using UnityEngine;

public class NautilusBehavior : Enemy
{
    [SerializeField] public float damage = 50;
    private float damageCooldown;
    [SerializeField] private GameObject cheesyPickup;
    private quaternion cheesyPickupRotation;


    void Start()
    {
        health = 200;
        pointWorth = 50;
        moveSpeed = 300f;
        rb.AddForce(transform.right * moveSpeed);
        cheesyPickupRotation = quaternion.Euler(53, -80, -156);
    }

    protected override void Update()
    {
     base.Update();
    
    }

    public override void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && damageCooldown <= 0)                                                                                // Als het object de tag "Player" heeft
        {
            print("hit");
            playerScript.Playerhealth -= damage;                                                                                 // doe damage
            damageCooldown = 0;
            damageCooldown += 2f;
        }
        base.FakeTriggerEnter(collision);
    }
    public override void DespawsnOnExit()
    {
        if (transform.position.x <= leftBottom.x - 3)                                                                        // Als de transform van het object aan de linkerkant het scherm verlaat
        {
            base.DespawsnOnExit();
            playerScript.Playerhealth -= damage;
        }
    }
    public override void Death()
    {
        if (health <= 0)
        {
            Instantiate(cheesyPickup, transform.position, cheesyPickupRotation);
            base.Death();
        }
    }
}
