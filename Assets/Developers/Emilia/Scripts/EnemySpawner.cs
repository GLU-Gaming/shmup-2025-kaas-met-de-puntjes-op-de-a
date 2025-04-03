using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] wave1Enemies;
    public GameObject[] wave2Enemies;
    public GameObject[] wave3Enemies;
    public GameObject[] wave4Enemies;
    public GameObject[] wave5Enemies;
    public Transform[] spawnPoints;
    public float spawnTime = 5f;
    public float spawnDelay = 3f;
    public int spawnLimit = 10;

    private int enemyCount = 0;
    public int waveCount = 0;

    void Start()
    {
        InvokeRepeating("AddEnemy", spawnDelay, spawnTime);
    }

    void AddEnemy()
    {
        if (waveCount == 0)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            int enemyIndex = Random.Range(0, wave1Enemies.Length);
            Instantiate(wave1Enemies[enemyIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            enemyCount++;
            if (enemyIndex == wave1Enemies.Length)
            {
                waveCount++;
                Debug.Log("wavecount");
            }
        }
        else
        {
            CancelInvoke("AddEnemy");
        }
    }
}