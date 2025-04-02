using UnityEngine;
using UnityEngine.UI;

public class imageScroller : MonoBehaviour
{
    [SerializeField] private RawImage img;
    [SerializeField] private float x, y;
    private GameObject Gamemanager;
    private GameBoss GameBoss;

    private void Awake()
    {
        Gamemanager = GameObject.FindWithTag("GameManager");
        GameBoss = Gamemanager.GetComponent<GameBoss>();
    }
    // Update is called once per frame
    void Update()
    {
        if (GameBoss.gameEnd != true)
        {
            img.uvRect = new Rect(img.uvRect.position + new Vector2(x, y) * Time.deltaTime, img.uvRect.size);
        }
    }
}
