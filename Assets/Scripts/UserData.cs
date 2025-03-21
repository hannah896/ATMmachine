using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public string userName;
    public int cash;
    public int balance;

    public UserData(string name, int cash, int balance)
    {
        this.userName = name;
        this.cash = cash;
        this.balance = balance;
    }

    public string Cash
    {
        get
        {
            return cash.ToString("N0");
        }
    }


    public string Balance
    {
        get
        {
            return balance.ToString("N0");
        }
    }
}
