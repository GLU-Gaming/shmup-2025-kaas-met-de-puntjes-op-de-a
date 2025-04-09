using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Boss;
    public BossBehavior BossScript;
    [SerializeField] List<Waves> waves = new List<Waves>();
    public Transform[] spawnPoints;
    public float spawnTime = 5f;
    public float spawnDelay = 3f;
    public int spawnLimit = 10;
    private GameObject Gamemanager;
    private GameBoss GameBoss;
    public int enemyCount = 0;
    public int waveCount = 0;
    private bool SpawnedBoss = false;
    bool SpawnDebounce = false;

    [System.Serializable]
    public class Waves {
        public GameObject[] Enemies;
    }

    [SerializeField] private TMP_Text wavecount;

    void Start()
    {
        Gamemanager = GameObject.FindWithTag("GameManager");
        GameBoss = Gamemanager.GetComponent<GameBoss>();
        SpawnDebounce=true;
        StartCoroutine(SpawnBarrage(2f, 2f));
        Boss = GameObject.FindWithTag("Boss");
        BossScript = Boss.GetComponent<BossBehavior>();
    }

    private void FixedUpdate()
    {
        if (!SpawnDebounce && enemyCount <= 0)
        {
            SpawnDebounce=true;
            waveCount++;
            StartCoroutine(SpawnBarrage(2f));
        }
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

    IEnumerator SpawnBarrage(float Delay, float DelayBeforeSpawn = 0f)
    {
        print("Spawning Wave: " + waveCount);
        wavecount.text = "Wave: " + waveCount + 1;
        yield return new WaitForSeconds(DelayBeforeSpawn);
        for(int i = 0; i < waves[waveCount].Enemies.Length; i++)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(waves[waveCount].Enemies[i], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            enemyCount++;
            yield return new WaitForSeconds(Delay);

            if (waveCount == 5 && SpawnedBoss != true)
            {
                Debug.Log("bosstime");
                BossScript.ActiveStatus = true;
                BossScript.startedMoving = false;
                SpawnedBoss = true;
            }
        }
        SpawnDebounce = false;
    }
}