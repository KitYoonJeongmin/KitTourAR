using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Image RunAway;
    //게임오버확인
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
    GameObject[] enemy;
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
            if (Score > 50)
            {
                Debug.Log("끝냉");
                gameover = true;
                playerControl.die();
                enemySpawner.gameover();
                RunAway.gameObject.SetActive(true);
                enemy = GameObject.FindGameObjectsWithTag("Enemy");
                for (int i = 0; i < enemy.Length; i++)
                {
                    Destroy(enemy[i]);
                }
            }
        }
    }
    public void gameOver()
    {
        playerControl.die();
        enemySpawner.gameover();
        gameoverText.gameObject.SetActive(true);
        gameover = true;
        SceneManager.LoadScene("Success");
    }
    // Update is called once per frame
    
    void scoreUpdate()
    {
        Score += Time.deltaTime;

        scoreText.text = "Score: " + (int)Score;

        //Debug.Log("점수 업! "+((int)Score).ToString());
    }

    public void changeScene()
    {
        SceneManager.LoadScene("KitMapScene");
        return;
    }
}
