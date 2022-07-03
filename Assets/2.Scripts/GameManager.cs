using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public usrDatManager usrDatManager;
    public userData userDataContainer;
    public Context context;
    public SceneController sc;
    public Text text;
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

    }

    public void goToMenu()
    {
        text.text = "Loading...";
        sc.LoadScene("Menu");
    }

    public void debug()
    {
        Debug.Log(true);
    }
}
