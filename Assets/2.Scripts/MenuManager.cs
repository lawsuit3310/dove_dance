using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    GameManager gameManager;

    public GameObject[] explainCharacter;
    private void Awake()
    {
        //gameManager 오브젝트를 찾음
        gameManager = FindObjectOfType<GameManager>();
        closeChrExplain();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void chrClick()
    {
        //가장 최근에 클릭한 오브젝트의 이름을 가져옴
        string selectedObject = EventSystem.current.currentSelectedGameObject.name;
        switch (selectedObject)
        {
            case "chr1":
                gameManager.Character = 1;
                break;
            case "chr2":
                gameManager.Character = 2;
                break;
            case "chr3":
                gameManager.Character = 3;
                break;
            case "chr4":
                gameManager.Character = 4;
                break;
            case "chr5":
                gameManager.Character = 5;
                break;
            case "chr6":
                gameManager.Character = 6;
                break;
            case "chr7":
                gameManager.Character = 7;
                break;
            case "chr8":
                gameManager.Character = 8;
                break;
        }

        Debug.Log(gameManager.Character);
        showChrExplain();
    }
    public void showChrExplain()
    {
        foreach (GameObject o in explainCharacter) {
            o.SetActive(true);
        }
    }

    public void closeChrExplain(){

        foreach (GameObject o in explainCharacter)
        {
            o.SetActive(false);
        }
    }

    public void startGame() {
        gameManager.sc.LoadScene("Game");
    }
}
