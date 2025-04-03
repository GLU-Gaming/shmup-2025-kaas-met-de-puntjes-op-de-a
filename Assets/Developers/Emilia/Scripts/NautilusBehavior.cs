using UnityEngine;

public class NautilusBehavior : Enemy
{

    [SerializeField] public float damage = 50;
    private float damageCooldown;


    void Start()
    {
        
    }

    void Update()
    {

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
