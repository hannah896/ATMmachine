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

    public Button depositBtn;
    public Button withdrawBtn;
    
    public GameObject Deposit;
    public GameObject Withdraw;

    public GameObject panel;

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
        Refresh();
    }

    public void withdraw(InputField inputField)
    {
        int value = int.Parse(inputField.text);
        withdraw(value);
    }
}