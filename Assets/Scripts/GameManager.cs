using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public UserData userData;
    
    public string userName;
    
    public int cash = 50000;
    public int balance = 100000;

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
    }
}