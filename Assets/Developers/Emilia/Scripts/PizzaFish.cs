using UnityEngine;

public class PizzaFish : Enemy
{

    [SerializeField] public float health = 100;
    [SerializeField] public float damage = 50;



    public override void DespawsnOnExit()
    {
        playerScript.Playerhealth -= damage;
        base.DespawsnOnExit();
    }

    void Update()
    {
        DespawsnOnExit();
    }
}
