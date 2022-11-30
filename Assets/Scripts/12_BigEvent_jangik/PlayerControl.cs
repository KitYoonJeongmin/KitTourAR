using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //사망확인
    bool isDie = false;
    string check;
    //기본속도
    public float speed = 5f;
    private bool isBtnDown = false;
    //충돌관리선언
    private float H, V;
    private Rigidbody2D playerRigidbody;

    GameManager instance;

    public void Ldown()
    {
        isBtnDown = true;
        check = "left";
    }
    public void Lup()
    {
        isBtnDown = false;
        check = "";
    }
    public void Rdown()
    {
        isBtnDown = true;
        check = "right";
    }
    public void Rup()
    {
        isBtnDown = false;
        check = "";
    }
    public void Udown()
    {
        isBtnDown = true;
        check = "up";
    }
    public void Uup()
    {
        isBtnDown = false;
        check = "";
    }
    public void Ddown()
    {
        isBtnDown = true;
        check = "down";
    }
    public void Dup()
    {
        isBtnDown = false;
        check = "";
    }
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
        if (isBtnDown)
        {
            switch (check)
            {
                case "left":
                    H = -1;
                    break;
                case "right":
                    H = 1;
                    break;
                case "up":
                    V = 1;
                    break;
                case "down":
                    V = -1;
                    break;
            }
        }
        else
        {
            H = 0;
            V = 0;
        }
        //H = Input.GetAxisRaw("Horizontal");
        //V = Input.GetAxisRaw("Vertical");
    }
    void Move()
    {
        Vector2 pos = this.gameObject.transform.position;
        Vector2 dirVec = new Vector2(H, V);
        if ((pos.x > 105f || pos.x < -94f))
        {
            dirVec.x *= -2;
        }
        if (pos.y > 99f || pos.y < -86f)
        {
            dirVec.y *= -2;
        }
        //dirVec = new Vector2(H, V);
        playerRigidbody.velocity = dirVec * speed;

    }
    public void die()
    {
        isDie = true;
        speed = 0;
    }
    void OnCollisionEnter2D(Collision2D col)
    {

        if(col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
            instance.gameOver();
        }
    }
}
