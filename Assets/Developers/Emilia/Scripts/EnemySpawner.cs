using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float spawnTime = 5f;
    public float spawnDelay = 3f;
    public int spawnLimit = 10;

    private int enemyCount = 0;

    void Start()
    {
        InvokeRepeating("AddEnemy", spawnDelay, spawnTime);
    }

    void AddEnemy()
    {
        if (enemyCount < spawnLimit)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemyPrefab, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            enemyCount++;
        }
        else
        {
            CancelInvoke("AddEnemy");
        }
    }
}