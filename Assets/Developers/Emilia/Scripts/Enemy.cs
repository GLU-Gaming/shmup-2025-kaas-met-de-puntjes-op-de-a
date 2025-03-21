using UnityEngine;

public abstract class Enemy : MonoBehaviour //abstract zorgt dat enemies zelf niet geinstantiate 
{
    void Awake()
    {

    }

    virtual protected void DamageOnExit()
    {

    }

    virtual protected void DespawsnOnExit()
    {

    }

    virtual protected void GetHit()
    {

    }

    void Update()
    {

    }
}
