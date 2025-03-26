using System.Runtime.CompilerServices;
using UnityEngine;

public class PizzaFish : Enemy
{

    [SerializeField] public float damage = 50;
    private float damageCooldown; 


    public override void DespawsnOnExit()
    {
        if (transform.position.x <= leftBottom.x - 3)                                                                        // Als de transform van het object aan de linkerkant het scherm verlaat
        {
            base.DespawsnOnExit();
            playerScript.Playerhealth -= damage;
        }
    }

    void Update()
    {
        Death();
        damageCooldown -= Time.deltaTime;
        DespawsnOnExit();
    }

    public override void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && damageCooldown <= 0)                                                                                // Als het object de tag "Player" heeft
        {
            playerScript.Playerhealth -= damage;                                                                                 // doe damage
            damageCooldown = 0;
            damageCooldown += 2f;
        }
        base.OnTriggerEnter(collision);
    }
}
