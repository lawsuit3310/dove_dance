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

    public void chkUsrDat()
    {
        // 유저 데이터가 들어있는 json 파일을 체크 해서 없으면 새로 생성 
        path = Directory.GetCurrentDirectory();
        dataPath = path + "/Assets/usrData.json";
        if (File.Exists(dataPath))
        {
            dataFs = new FileStream(dataPath, FileMode.Open);
        }
        else
        {
            dataFs = new FileStream(dataPath, FileMode.Create);
            dataFs.Close();
            using (sw = new StreamWriter(dataPath))
            {
                sw.Write("{\"DUI\" : \"" + deviceInitializer + "\"}");
            }
            dataFs = new FileStream(dataPath, FileMode.Open);

        }

        dataFs.Close();
    }

    public void ReadData() {
        usrData = File.ReadAllText(dataPath);
    }

    public T WriteData<T>(string _fileName, T data) {
        dataPath = path + "/Assets/" + _fileName;
        try
        {
            if (File.Exists(dataPath))
            {
                string json = JsonUtility.ToJson(data);
                Debug.Log($"json : {json}");
                File.WriteAllText(dataPath, json);
            }
            else {
                Debug.Log("File does not exist!");
            }
        }
        catch (Exception ex) {
            Debug.LogException(ex);
        }
        return default;
    }

    public T ReadData<T>(string _fileName) {
        dataPath = path + "/Assets/" + _fileName;
        if (File.Exists(dataPath)){
            usrData = File.ReadAllText(dataPath);
            T t = JsonUtility.FromJson<T>(usrData);
            return t;
        }
        return default;
    }
}
