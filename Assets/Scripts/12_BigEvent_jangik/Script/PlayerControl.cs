using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    //���Ȯ��
    bool isDie = false;

    //�⺻�ӵ�
    public float speed = 5f;

    //�浹��������
    private float H, V;
    private Rigidbody2D playerRigidbody;

    GameManager instance;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        instance = GameManager.Instance;
    }
    void Update()
    {
        MoveSet();
    }

    void FixedUpdate()
    {
        Move();
    }

    void MoveSet()
    {
        H = Input.GetAxisRaw("Horizontal");
        V = Input.GetAxisRaw("Vertical");
        
    }

    public void die()
    {
        isDie = true;
        speed = 0;
    }
    void Move()
    {
        Vector2 dirVec = new Vector2(H, V);

        playerRigidbody.velocity = dirVec * speed;

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            instance.gameOver();
            Destroy(col.gameObject);
        }
    }
    
    
    
    

    
}
