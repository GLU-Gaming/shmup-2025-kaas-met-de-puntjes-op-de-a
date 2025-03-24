using UnityEngine;

public class PizzaFish : Enemy
{

    [SerializeField] public float health = 100;
    [SerializeField] public float damage = 50;



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
        DespawsnOnExit();
    }
}
