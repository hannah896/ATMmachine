using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{
    public Text UserName;
    public Text Balance;
    public Text Cash;
    public Text Error;

    public Button depositBtn;
    public Button withdrawBtn;
    
    public GameObject Deposit;
    public GameObject Withdraw;

    public GameObject panel;
    public GameObject error;

    public InputField _name;
    public InputField _money;

    private void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        UserName.text = GameManager.Instance.userName;
        Balance.text = GameManager.Instance.userData.Balance;
        Cash.text = GameManager.Instance.userData.Cash;
    }

    public void deposit(int value)
    {
        if (GameManager.Instance.userData.cash < value || value < 0)
        {
            panel.SetActive(true);
            return;
        }
        Debug.Log("처리해드렸습니다~");
        GameManager.Instance.userData.cash -= value;
        GameManager.Instance.userData.balance += value;
        GameManager.Instance.SaveData();
        Refresh();
    }

    public void deposit(InputField inputField)
    {
        int value = int.Parse(inputField.text);
        deposit(value);
    }

    public void withdraw(int value)
    {
        if (GameManager.Instance.userData.balance < value || value < 0)
        {
            panel.SetActive(true);
            return;
        }
        Debug.Log("처리해드렸습니다~");
        GameManager.Instance.userData.balance -= value;
        GameManager.Instance.userData.cash += value;
        GameManager.Instance.SaveData();
        Refresh();
    }

    public void withdraw(InputField inputField)
    {
        int value = int.Parse(inputField.text);
        withdraw(value);
    }

    public void depositR(int value)
    {
        Debug.Log("처리해드렸습니다~");
        GameManager.Instance.receiverData.balance += value;
        GameManager.Instance.SaveData(GameManager.Instance.receiverData);
        Refresh();
    }

    public void withdrawR(int value)
    {
        if (GameManager.Instance.userData.balance < value || value < 0)
        {
            panel.SetActive(true);
            return;
        }
        Debug.Log("처리해드렸습니다~");
        GameManager.Instance.userData.balance -= value;
        GameManager.Instance.SaveData();
        Refresh();
    }

    public void Send()
    {
        if (!Check(_name, _money)) return;
        withdrawR(int.Parse(_money.text));
        depositR(int.Parse(_money.text));
    }

    private bool Check(InputField name, InputField money)
    {
        //대상, 금액을 입력했나 확인하기
        if (name.text == null || money.text == null)
        {
            error.SetActive(true);
            Error.text = "입력정보를 확인해주세요.";
            return false;
        }
        int value = int.Parse(money.text);
        //금액이 충분한가
        if (GameManager.Instance.userData.balance < value || value < 0)
        {
            error.SetActive(true);
            Error.text = "잔액이 부족합니다.";
            return false;
        }

        GameManager.Instance.userID = name.text;

        //실제 있는 대상인지 확인하기
        if (!GameManager.Instance.LoadData(name.text, GameManager.Instance.receiverData))
        {
            error.SetActive(true);
            Error.text = "대상이 없습니다.";
            return false;
        }

        return true;
    }
}
