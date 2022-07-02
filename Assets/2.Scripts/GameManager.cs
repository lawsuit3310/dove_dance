using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    usrDatManager usrDatManager;
    // Start is called before the first frame update
    void Awake()
    {
        usrDatManager = new usrDatManager();
        Debug.Log(usrDatManager.usrData);
        usrDatManager.ReadData();

        #region Testing Area
        #endregion
    }

    void Start(){
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
