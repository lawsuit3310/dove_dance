using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxSpd = 1f;
    public float JumpScale = 1f;
    GameManager gameManager;
    Rigidbody2D rigidbody2D;

    bool isJumpable = true;
    // Start is called before the first frame update

    private void Awake()
    {
        //gameManager 오브젝트를 찾음
        gameManager = FindObjectOfType<GameManager>();
        getPlayerReference(gameManager.Character);
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //실제 조작
        if (Input.GetKey(KeyCode.Space))
        {
            this.rigidbody2D.velocity = new Vector2(this.rigidbody2D.velocity.x > 0 ? maxSpd : -maxSpd, 0);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            this.rigidbody2D.velocity = new Vector2(0, this.rigidbody2D.velocity.y);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            this.rigidbody2D.velocity -= Vector2.right;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbody2D.velocity += Vector2.right;
        }

        //플레이어의 이동 속도 등을 제한 하는 부분 
        if (Mathf.Abs(rigidbody2D.velocity.x) > maxSpd)
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x > 0 ? maxSpd : -1 * maxSpd, rigidbody2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.W) && isJumpable)
        {
            rigidbody2D.velocity += Vector2.up * JumpScale;
        }

        isJumpable = this.rigidbody2D.velocity.y == 0 ? true : false;
        Debug.Log(rigidbody2D.velocity.y);
    }

    

    void getPlayerReference(int id)
    {
        int Character = gameManager.Character;
        Debug.Log(Character);
    }
}
