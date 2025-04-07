using UnityEngine;

public class TimedDespawn : MonoBehaviour
{
    [SerializeField] private float TimeAlive = 2f;

    void Update()
    {
        TimeAlive -= Time.deltaTime;
        if (TimeAlive <= 0)
        {
            Destroy(gameObject);
        }
    }
}
