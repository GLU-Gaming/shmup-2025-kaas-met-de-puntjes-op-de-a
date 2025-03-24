using UnityEngine;

public class PizzaFish : Enemy
{

    [SerializeField] public float health = 100;
    [SerializeField] public float damage = 50;

    void Start()
    {

    }


    void Update()
    {
        DamageOnExit();
    }
}
