using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    GameManager gameManager;

    private bool isPlayable = true;
    Context txt;
    Character chr;

    public GameObject[] explainCharacter;
    private void Awake()
    {
        //gameManager 오브젝트를 찾음
        gameManager = FindObjectOfType<GameManager>();
        closeChrExplain();
    }
    // Update is called once per framel

    public void chrClick()
    {
        //가장 최근에 클릭한 오브젝트의 이름을 가져옴
        string selectedObject = EventSystem.current.currentSelectedGameObject.name;
        txt = gameManager.usrDatManager.ReadData<Context>("text.json");
        switch (selectedObject)
        {
            case "chr1":
                gameManager.Character = 1;
                chr = JsonUtility.FromJson<Character>(txt.chr1);
                isPlayable = gameManager.userDataContainer.chr1 == "locked" ? false : true;
                break;
            case "chr2":
                gameManager.Character = 2;
                chr = JsonUtility.FromJson<Character>(txt.chr2);
                isPlayable = gameManager.userDataContainer.chr2 == "locked" ? false : true;
                break;
            case "chr3":
                gameManager.Character = 3;
                chr = JsonUtility.FromJson<Character>(txt.chr3);
                isPlayable = gameManager.userDataContainer.chr3 == "locked" ? false : true;
                break;
            case "chr4":
                gameManager.Character = 4;
                chr = JsonUtility.FromJson<Character>(txt.chr4);
                isPlayable = gameManager.userDataContainer.chr4 == "locked" ? false : true;
                break;
            case "chr5":
                chr = JsonUtility.FromJson<Character>(txt.chr5);
                gameManager.Character = 5;
                isPlayable = gameManager.userDataContainer.chr5 == "locked" ? false : true;
                break;
            case "chr6":
                chr = JsonUtility.FromJson<Character>(txt.chr6);
                gameManager.Character = 6;
                isPlayable = gameManager.userDataContainer.chr6 == "locked" ? false : true;
                break;
            case "chr7":
                chr = JsonUtility.FromJson<Character>(txt.chr7);
                gameManager.Character = 7;
                isPlayable = gameManager.userDataContainer.chr7 == "locked" ? false : true;
                break;
            case "chr8":
                chr = JsonUtility.FromJson<Character>(txt.chr8);
                gameManager.Character = 8;
                isPlayable = gameManager.userDataContainer.chr8 == "locked" ? false : true;
                break;
        }
        showChrExplain();
    }
    public void showChrExplain()
    {
        foreach (GameObject o in explainCharacter) {
            o.SetActive(true);
        }

        isPlayableCheck();
    }

    public void closeChrExplain(){

        foreach (GameObject o in explainCharacter)
        {
            o.SetActive(false);
        }

    }

    void isPlayableCheck()
    {
        Text name = explainCharacter[3].GetComponent<Text>();
        Text explanation = explainCharacter[4].GetComponent<Text>();

        if (!isPlayable)
        {
            //캐릭터가 잠겼을 때의 동작
            name.text = "???";
            string temp = "";
            for (int i = 0; i < chr.condition.Length; i++)
            {
                temp += chr.explanation[i];
                if (i % 27 == 0 && i != 0)
                {
                    temp += "\n";
                }
            }
            explanation.text = chr.condition;
            //게임 시작 버튼 숨김
            explainCharacter[5].SetActive(false);
        }
        else
        {
            Debug.Log("The Game is Playable.");

            name.text = chr.name;

            string temp = "";
            for (int i = 0; i < chr.explanation.Length; i++)
            {
                temp += chr.explanation[i];
                if (i % 27 == 0 && i != 0)
                {
                    temp += "\n";
                }
            }
            explanation.text = temp;
        }
    }

    public void startGame() {
        gameManager.sc.LoadScene("Game");
    }
}
