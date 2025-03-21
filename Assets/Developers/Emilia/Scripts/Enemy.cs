using Unity.VisualScripting;
using UnityEngine;

public abstract class Enemy : MonoBehaviour //abstract moet erbij omdat er geen enkele instantie of object is die dit script er op heeft 
{
    [SerializeField] Vector3 rightTop;                                                                                  // Een lege Vector3 die later de waarde krijgt van de rechter-boven hoek van het scherm
    [SerializeField] Vector3 leftBottom;                                                                                // Een lege Vector3 die later de waarde krijgt van de links-onder hoek van het scherm
    private Rigidbody rb;
    [SerializeField] private float MoveSpeed = 2f;

    void Awake()
    {
        rightTop = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, 20f));                                          // haalt boven rechtse hoek van het speelveld  
        leftBottom = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 20f));                                        // haalt linker onderste hoek van het speelveld
        rb = GetComponent<Rigidbody>();
        Vector3 transformdown = transform.right * -1f;
        rb.linearVelocity = transformdown * MoveSpeed;
    }

    virtual protected void DamageOnExit()
    {
        if (transform.position.x < leftBottom.x)                                                                        // Als de transform van het object aan de linkerkant het scherm verlaat
        {
            //deal damage to player
        }
    }

    virtual protected void DespawsnOnExit()
    {
        if (transform.position.x <= leftBottom.x - 3)                                                                        // Als de transform van het object aan de linkerkant het scherm verlaat
        {
            Destroy(gameObject);                                                                                        // verwijder het object
        }
    }

    virtual protected void OnCollisionEnter()
    {
        if (gameObject.tag == "Player")                                                                                // Als het object de tag "Player" heeft
        {
            Destroy(gameObject);                                                                                        // verwijder het object
        }
    }

    void Update()
    {
        DespawsnOnExit();
        DamageOnExit();
    }
}
