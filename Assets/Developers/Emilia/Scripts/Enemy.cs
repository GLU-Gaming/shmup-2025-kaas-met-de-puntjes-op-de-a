using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Enemy : MonoBehaviour //abstract moet erbij omdat er geen enkele instantie of object is die dit script er op heeft 
{
    [SerializeField] protected Vector3 rightTop;                                                                                  // Een lege Vector3 die later de waarde krijgt van de rechter-boven hoek van het scherm
    [SerializeField] public Vector3 leftBottom;                                                                                // Een lege Vector3 die later de waarde krijgt van de links-onder hoek van het scherm
    protected Rigidbody rb;
    [SerializeField] private float MoveSpeed;

    private GameObject player;
    public PlayerController playerScript;
    [SerializeField] public float health = 150;
    protected GameObject Gamemanager;
    EnemySpawner spawner;
    protected GameBoss GameBoss;
    protected float pointWorth;                                                                                          // Hoeveel punten de speler krijgt als hij de enemy dood maakt
    protected float moveSpeed;




    void Awake()
    {

        spawner = GameObject.FindFirstObjectByType<EnemySpawner>();

        rightTop = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, 20f));                                                  // haalt boven rechtse hoek van het speelveld  
        leftBottom = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 20f));                                                // haalt linker onderste hoek van het speelveld
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * -moveSpeed);
        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<PlayerController>();
        Gamemanager = GameObject.FindWithTag("GameManager");
        GameBoss = Gamemanager.GetComponent<GameBoss>();
    }

    public virtual void DespawsnOnExit()
    {
        if (transform.position.x <= leftBottom.x - 3)                                                                           // Als de transform van het object aan de linkerkant het scherm verlaat
        {
            Destroy(gameObject);                                                                                                // verwijder het object
            spawner.enemyCount--;
        }
    }

    public virtual void FakeTriggerEnter(Collider collission)
    {

        if (collission.gameObject.tag == "Bullet")                                                                              // Als het object de tag "Player" heeft
        {
            health -= 50;                                                                                                       // krijgt damage
        }
    }

    public virtual void OnTriggerEnter(Collider collission)
    {
        print("hit base");
        if (collission.gameObject.tag == "Bullet")                                                                              // Als het object de tag "Player" heeft
        {
            health -= 50;                                                                                                       // krijgt damage
        }
    }

    public virtual void Death()
    {
        if (health <= 0)
        {
            GameBoss.CurrentScore += pointWorth;
            Destroy(gameObject);
        }
    }

        protected virtual void Update()
    {
        if (GameBoss.gameEnd != true)
        {
            Death();
            DespawsnOnExit();
        }

        if (health <= 0) 
        {
            Destroy(gameObject);
            spawner.enemyCount--;
        }

        //als enemy aan de linkerkant van het scherm is doodmaken zodat de waves correct blijven werken
        //if(transform.position.x <= -22.5f)
        //{

        //    Destroy(gameObject);
        //}
    }
}
