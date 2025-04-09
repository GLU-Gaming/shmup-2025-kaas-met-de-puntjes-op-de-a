using UnityEngine;

public class EnvironmentMover : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private GameObject newTerrain;
    [SerializeField] private GameObject TerrainSpawn;
    private bool SpawnedSuccessor;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * -300);
        SpawnedSuccessor = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.position.x <= 230 && SpawnedSuccessor == false)
        {
            Instantiate(newTerrain, TerrainSpawn.transform.position, gameObject.transform.rotation);
            SpawnedSuccessor = true;
        }
        else if(rb.position.x <= 170)
        {
            Destroy(gameObject);
        }
    }
}
