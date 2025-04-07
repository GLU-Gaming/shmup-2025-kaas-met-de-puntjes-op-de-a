using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    public ParticleSystem particleSysteem;

    void Start()
    {
        particleSysteem = GetComponent<ParticleSystem>();
        particleSysteem.Play(); // Start the particle system
    }

    void Update()
    {
        if (!particleSysteem.isEmitting)
        {
            particleSysteem.Play(); // Resume emitting if it has stopped
        }
    }
}
