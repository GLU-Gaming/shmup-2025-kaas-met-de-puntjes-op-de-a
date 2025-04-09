using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class MeatballlPuffer : Enemy
{
    [SerializeField] public float damage = 50;
    private float damageCooldown;

    [SerializeField] private GameObject puffballexplosion;
    public bool explosionBool = false;

    protected void Start()
    {
        health = 100;
        pointWorth = 150;
        moveSpeed = 500f;
        rb.AddForce(transform.right * moveSpeed);
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

    protected override void Update()
    {
        base.Update();
        Death();
        damageCooldown -= Time.deltaTime;
        DespawsnOnExit();
        if (health <= 0 && explosionBool == false)
        {
            ExplodeOnDeath();
            explosionBool = true;
        }
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

    public void ExplodeOnDeath()
    {
        if (explosionBool == false)
        {
            Instantiate(puffballexplosion, transform.position, Quaternion.identity);
            explosionBool = true;
        }

    }
}
