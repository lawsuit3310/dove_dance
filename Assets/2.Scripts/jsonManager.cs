using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jsonManager : MonoBehaviour
{
    #region Variable
    public FileStream dataFs;
    StreamWriter sw;
    StreamReader sr;
    //현재 게임이 실행 중인 경로
    string path;
    //게임 데이터를 저장 할 경로
    string dataPath;
    string deviceInitializer {get; set;}
    #endregion

    public void Awake() {
        
        path = Directory.GetCurrentDirectory();
        dataPath = path + "/Assets/usrData.json";
        deviceInitializer = SystemInfo.deviceUniqueIdentifier;
        if(File.Exists(dataPath))
        {
            dataFs  = new FileStream(dataPath, FileMode.Open);
        }
        else
        {
            dataFs = new FileStream(dataPath, FileMode.Create); 
            try{
                sw = new StreamWriter(dataFs);
                sw.Write("{\"DUI\" : \""+deviceInitializer+"\"}");
                sw.Close();
            }
            catch(Exception e){
                Debug.Log(e);
            }
        }

    }
    public void Start(){
        sr = new StreamReader(dataFs);
        Debug.Log(sr.ReadToEnd());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
