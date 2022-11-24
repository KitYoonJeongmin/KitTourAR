using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int score = 0;
    bool gameover = false;
    //플레이어 컨트롤
    public PlayerControl playerControl;
    //게임오버 텍스트
    public Text gameoverText;
    //몹스포너 변수
    public EnemySpawner enemySpawner;
    //점수표시
    public Text scoreText;
    float Score;

    private GameManager() { }
    private static GameManager instance = null;

    private Rigidbody2D playerRigidbody;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }

            return instance;
        }
    }
    void Start()
    {
        gameoverText.gameObject.SetActive(false);
        
    }
    void Update()
    {
        if (!gameover)
        {
            scoreUpdate();
        }
    }
    public void gameOver()
    {
        playerControl.die();
        enemySpawner.gameover();
        gameoverText.gameObject.SetActive(true);
        gameover = true;
    }
    // Update is called once per frame
    
    void scoreUpdate()
    {
        Score += Time.deltaTime;

        scoreText.text = "Score: " + (int)Score;
    }

}
