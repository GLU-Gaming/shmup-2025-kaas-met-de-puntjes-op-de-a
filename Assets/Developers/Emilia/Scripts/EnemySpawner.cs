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
    private GameObject Gamemanager;
    private GameBoss GameBoss;
    private int enemyCount = 0;
    public int waveCount = 0;

    void Start()
    {
        Gamemanager = GameObject.FindWithTag("GameManager");
        GameBoss = Gamemanager.GetComponent<GameBoss>();
        InvokeRepeating("AddEnemy", spawnDelay, spawnTime);
    }

    void AddEnemy()
    {
        if (enemyCount < spawnLimit && GameBoss.gameEnd != true)
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