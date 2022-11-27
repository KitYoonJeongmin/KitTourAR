using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    //��
    public GameObject[] enemys;
    //�÷��̾� ��ġ
    public Transform playerTransfrom;
    //�ִ�Ÿ�
    public float maxDist = 10f;
    //�ּҰŸ�
    public float minDist = 3f;

    public float timeSpawnMax = 5f; //�ִ� �����ֱ�
    public float timeSpawnMin = 2f; //�ּ� �����ֱ�
    public float timeSpawn;
    private float lastSpawn; // ���� �ֱ� ����
    // Start is called before the first frame update
    void Start()
    {
        //�����ֱ� ���̿��� ���� �ʱ�ȭ
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
