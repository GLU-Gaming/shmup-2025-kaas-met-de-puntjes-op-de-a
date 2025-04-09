using UnityEngine;

public class WaveAnimation : MonoBehaviour
{

    [SerializeField] GameObject animator;
    private EnemySpawner enemyspawner;


    void Start()
    {
        enemyspawner.GetComponent<playwaveanimat>();
    }

    void Update()
    {
        
    }
}
