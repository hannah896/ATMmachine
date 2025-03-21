using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public UserData userData;
    
    public string userName;
    
    public int cash = 50000;
    public int balance = 100000;

    private string path = "";

    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        userData = new UserData(userName, cash, balance);
        path = Application.persistentDataPath;
    }

    void Start()
    {
        LoadData();
        userName = userData.userName;
        cash = userData.cash;
        balance = userData.balance;
    }

    public void SaveData()
    {
        path += $"{userData.ID}.txt";
        string saveData = JsonUtility.ToJson(userData);
        //앞에는 저장 경로, 뒤에는 저장할 내용을json으로 바꿔서 저장
        File.WriteAllText(path, saveData);
    }
    
    public bool LoadData(string id)
    {
        path += Application.persistentDataPath + $"{id}.txt";
        //읽어오는거라 경로만 있으면 됨.
        if (File.Exists(path))
        {
            string LoadData = File.ReadAllText(path);
            userData = JsonUtility.FromJson<UserData>(LoadData);
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool LoadData()
    {
        return LoadData(userData.ID);
    }
}