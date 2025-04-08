using UnityEngine;

public class EnvironmentMover : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private GameObject newTerrain;
    private GameObject TerrainSpawn;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * -1);
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.position.x < 208)
        {
            Instantiate(newTerrain, TerrainSpawn.transform.position, gameObject.transform.rotation);
        }
    }
}
