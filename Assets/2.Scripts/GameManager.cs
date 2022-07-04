using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    usrDatManager usrDatManager;
    userData userDataContainer;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);    
        userDataContainer = new userData();
        usrDatManager = new usrDatManager();
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
            Debug.Log("true");
        }
    }
}
