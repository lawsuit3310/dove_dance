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
        //gameManager ������Ʈ�� ã��
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
        //���� ����
        if (Input.GetKey(KeyCode.Space) && rigidbody2D.velocity.y < 0 && rigidbody2D.velocity.x != 0)
        {
            this.rigidbody2D.velocity = new Vector2(this.rigidbody2D.velocity.x > 0 ? maxSpd : -maxSpd, -0.5f);
        }
        else if (Input.GetKeyUp(KeyCode.Space) && !isJumpable)
        {
            this.rigidbody2D.velocity = new Vector2(0, this.rigidbody2D.velocity.y);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            this.rigidbody2D.velocity -= Vector2.right;
            playerFilp(false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbody2D.velocity += Vector2.right;
            playerFilp(true);
        }
        if (Input.GetKey(KeyCode.Space) && isJumpable)
        {
            rigidbody2D.velocity += Vector2.up * JumpScale;
        }

        //�÷��̾��� �̵� �ӵ� ���� ���� �ϴ� �κ� 
        if (Mathf.Abs(rigidbody2D.velocity.x) > maxSpd)
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x > 0 ? maxSpd : -1 * maxSpd, rigidbody2D.velocity.y);

       

        isJumpable = this.rigidbody2D.velocity.y == 0 ? true : false;
    }

    

    void getPlayerReference(int id)
    {
        int Character = gameManager.Character;
        Debug.Log(Character);
    }

    void playerFilp(bool status)
    {
        //true�� ������ false�� �ȵ�����
        if (status)
        {
            this.transform.localScale = new Vector3(-1, 1, this.transform.localScale.z);
        }
        else
        {
            this.transform.localScale = new Vector3(1, 1, this.transform.localScale.z);
        }
    }
}
