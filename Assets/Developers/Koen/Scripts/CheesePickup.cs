using UnityEngine;

public class CheesePickup : BasePickup
{
    public override void Activate()
    {
        GameBoss.CurrentScore += 1000;
        base.Activate();
    }
}
