using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameManager gameManager;
    // Start is called before the first frame update

    private void Awake()
    {
        //gameManager ������Ʈ�� ã��
        gameManager = FindObjectOfType<GameManager>();
        getPlayerReference(gameManager.Character);
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void getPlayerReference(int id)
    {
        int Character = gameManager.Character;
        Debug.Log(Character);
    }
}
