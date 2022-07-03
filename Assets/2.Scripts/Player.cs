using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float spd = 0.05f; 
    GameManager gameManager;
    Transform playerTransform;
    // Start is called before the first frame update

    private void Awake()
    {
        //gameManager 오브젝트를 찾음
        gameManager = FindObjectOfType<GameManager>();
        getPlayerReference(gameManager.Character);
        playerTransform = GetComponent<Transform>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            playerTransform.position = new Vector2(playerTransform.position.x - spd, playerTransform.position.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerTransform.position = new Vector2(playerTransform.position.x + spd, playerTransform.position.y);
        }
    }

    

    void getPlayerReference(int id)
    {
        int Character = gameManager.Character;
        Debug.Log(Character);
    }
}
