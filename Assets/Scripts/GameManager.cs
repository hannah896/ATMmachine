using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public UserData userData;
    public UserData receiverData;

    public string userID;
    public string userName;
    
    public int cash = 50000;
    public int balance = 100000;

    private string indexPath;


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

        indexPath = Path.Combine(Application.persistentDataPath, "UserIndex.txt");
    }

    void Start()
    {
        LoadData();
        userName = userData.userName;
        cash = userData.cash;
        balance = userData.balance;
    }

    public void SaveData(UserData user)
    {
        //유저정보 파일 생성
        string savePath = Path.Combine(Application.persistentDataPath, $"{user.ID}.txt");
        string saveData = JsonUtility.ToJson(user);
        File.WriteAllText(savePath, saveData);
        Debug.Log($"저장 완료: {savePath}");
    }

    public void SaveData()
    {
        SaveData(userData);
    }

    public bool LoadData(string id, UserData user)
    {
        string loadPath = Path.Combine(Application.persistentDataPath, $"{id}.txt");
        Debug.Log(loadPath);
        if (File.Exists(loadPath))
        {
            string loadData = File.ReadAllText(loadPath);
            user = JsonUtility.FromJson<UserData>(loadData);
            return true;
        }
        else
        {
            return false;
        }
    }


    public bool LoadData()
    {
        return LoadData(userData.ID, userData);
    }
}