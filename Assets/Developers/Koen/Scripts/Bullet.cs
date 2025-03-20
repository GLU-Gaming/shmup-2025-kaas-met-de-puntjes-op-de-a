using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float TimeAlive = 2f;
    [SerializeField] private Rigidbody rb;

    private void Start()
    {
        //rb.AddForce();
    }

    // Update is called once per frame
    void Update()
    {
        TimeAlive -= Time.deltaTime;
        if (TimeAlive <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter()
    {
        Destroy(gameObject);
    }
}
