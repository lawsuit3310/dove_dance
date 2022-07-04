using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    usrDatManager usrDatManager;
    userData userDataContainer;
    SceneController sc;

    public GameObject sceneController;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);    
        userDataContainer = new userData();
        usrDatManager = new usrDatManager();
        sc = sceneController.GetComponent<SceneController>();
        usrDatManager.ReadData();


        #region Testing Area

        #endregion
    }

    void Start(){
        userDataContainer = usrDatManager.ReadData<userData>("usrData.json");
        Debug.Log($"json load was successful {userDataContainer.DUI}");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount != 0) {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended) {
                sc.LoadScene("Menu");
            }
        }
    }
}
