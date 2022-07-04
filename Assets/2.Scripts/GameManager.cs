using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    usrDatManager usrDatManager;
    public userData userDataContainer;
    public SceneController sc;

    public GameObject sceneController;

    public int Character = 0;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);    
        userDataContainer = new userData();
        usrDatManager = new usrDatManager();
        sc = sceneController.GetComponent<SceneController>();
        userDataContainer = usrDatManager.ReadData<userData>("usrData.json");
        Debug.Log($"json load was successful {userDataContainer.DUI}");

        #region Testing Area
        try
        {

        }
        catch(Exception e)
        {
            Debug.Log(e);
        }
        #endregion
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount != 0) {
            //리눅스에선 이거 안먹음
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended && SceneManager.GetActiveScene().name == "TitleScreen")
            {
                
            }
        }
    }

    public void goToMenu()
    {
        sc.LoadScene("Menu");
    }

    public void debug()
    {
        Debug.Log(true);

    }
}
