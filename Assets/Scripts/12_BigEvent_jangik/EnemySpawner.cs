using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    //몹
    public GameObject[] enemys;
    //플레이어 위치
    public Transform playerTransfrom;
    //최대거리
    public float maxDist = 10f;
    //최소거리
    public float minDist = 3f;

    public float timeSpawnMax = 5f; //최대 생성주기
    public float timeSpawnMin = 2f; //최소 생성주기
    public float timeSpawn;
    private float lastSpawn; // 가장 최근 생성
    // Start is called before the first frame update
    void Start()
    {
        //생성주기 사이에서 랜덤 초기화
        timeSpawn = Random.Range(timeSpawnMin, timeSpawnMax);
        lastSpawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= lastSpawn + timeSpawn)
        {
            lastSpawn = Time.time;
            timeSpawn = timeSpawnMax-(Time.deltaTime * 0.1f);

            Spawn();
        }
    }

    void Spawn()
    {
        Vector2 spawnPos = GetRandomPoint(playerTransfrom.position, maxDist);
        GameObject selectedEnemy = enemys[Random.Range(0, enemys.Length)];
        GameObject enemy = Instantiate(selectedEnemy, spawnPos, Quaternion.identity);
        enemy es = enemy.GetComponent<enemy>();
        es.init(playerTransfrom);
    }
    Vector2 GetRandomPoint(Vector2 center, float distance)
    {  
        Vector2 randomPos = Random.insideUnitCircle * distance + center;
        return randomPos;
    }
    public void gameover()
    {
        gameObject.SetActive(false);
    }
}
