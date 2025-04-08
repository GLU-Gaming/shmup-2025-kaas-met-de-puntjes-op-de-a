using UnityEngine;

public class NautilusBehavior : Enemy
{
    [SerializeField] public float damage = 50;
    private float damageCooldown;


    void Start()
    {
        pointWorth = 50;
        moveSpeed = 300f;
        rb.AddForce(transform.right * moveSpeed);

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

            //explode on hit
        }
    }
}
