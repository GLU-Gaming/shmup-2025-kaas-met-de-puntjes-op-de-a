using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class pepperonibullet : MonoBehaviour
{
    [SerializeField] private float TimeAlive = 2f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float MoveSpeed = 1f;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
       Vector3 transformdown = transform.right * -1.0f;
        rb.linearVelocity = transformdown * MoveSpeed;
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
    private void OnTriggerEnter()
    {
        Destroy(gameObject);
    }
}
