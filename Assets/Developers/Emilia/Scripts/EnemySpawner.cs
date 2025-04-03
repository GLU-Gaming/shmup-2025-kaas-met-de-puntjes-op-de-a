using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<Waves> waves = new List<Waves>();
    public Transform[] spawnPoints;
    public float spawnTime = 5f;
    public float spawnDelay = 3f;
    public int spawnLimit = 10;
    private GameObject Gamemanager;
    private GameBoss GameBoss;
    private int enemyCount = 0;
    public int waveCount = 0;

    [System.Serializable]
    public class Waves {
        public GameObject[] Enemies;
    }

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
            int enemyIndex = Random.Range(0, waves[waveCount].Enemies.Length);
            Instantiate(waves[waveCount].Enemies[enemyIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            enemyCount++;
            if (enemyIndex == waves[waveCount].Enemies.Length)
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