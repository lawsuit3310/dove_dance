using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class usrDatManager{
    #region Variable
    public FileStream dataFs;
    StreamWriter sw;
    StreamReader sr;
    //현재 게임이 실행 중인 경로
    string path;
    //게임 데이터를 저장 할 경로
    string dataPath;
    public string usrData = "";
    string deviceInitializer {get;} = SystemInfo.deviceUniqueIdentifier;
    #endregion
    
    public usrDatManager(){
        chkUsrDat();
        ReadData();
    }

    public void chkUsrDat() {
        
        path = Directory.GetCurrentDirectory();
        dataPath = path + "/Assets/usrData.json";
        if(File.Exists(dataPath)){
            dataFs  = new FileStream(dataPath, FileMode.Open);
        }
        else{
            dataFs = new FileStream(dataPath, FileMode.Create);
            dataFs.Close();
            using(sw = new StreamWriter(dataPath)){
                sw.Write("\n{\n\t\"DUI\" : \""+deviceInitializer+"\"\n}\n");
            }
            dataFs = new FileStream(dataPath, FileMode.Open);

        }

    }
    public void ReadData(){
        sr = new StreamReader(dataFs);
        usrData = sr.ReadToEnd();
    }

}
