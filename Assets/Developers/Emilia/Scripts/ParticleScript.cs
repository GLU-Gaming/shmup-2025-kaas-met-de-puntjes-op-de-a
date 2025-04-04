using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    public ParticleSystem particleSystem;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        particleSystem.Play(); // Start the particle system
    }

    void Update()
    {
        if (!particleSystem.isEmitting)
        {
            particleSystem.Play(); // Resume emitting if it has stopped
        }
    }
}
