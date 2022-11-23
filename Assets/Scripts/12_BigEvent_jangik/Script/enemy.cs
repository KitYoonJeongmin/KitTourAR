using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform playerTransform;
    Transform enemyTransform;
    Rigidbody2D enemyRigidbody;
    public int speed;
    public void init(Transform playerTransform)
    {
        this.playerTransform = playerTransform;
    }
    // Start is called before the first frame update
    void Start()
    {
        enemyTransform = GetComponent<Transform>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveSet();
    }

    Vector2 vec;
    void FixedUpdate()
    {
        Move();
    }
    void MoveSet()
    {
        vec = playerTransform.position - enemyTransform.position;

        vec.Normalize();
    }
    void Move()
    {
        enemyRigidbody.velocity = vec * speed;
    }
}
