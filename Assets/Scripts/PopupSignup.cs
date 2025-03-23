using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSignup : MonoBehaviour
{
    [Header("SignupInfo")]
    public InputField nameInput;
    public InputField idInput;
    public InputField pwInput;
    public InputField pwconformInput;
    
    public GameObject panel;
    public GameObject screen;

    public Button SignupBtn;
    public Button CancelBtn;

    public Text error;

    public void Signup()
    {
        if (!Check())
        {
            return;
        }

        UserData data = GameManager.Instance.userData;

        data.userName = nameInput.text;

        data.ID = idInput.text;
        data.PW = pwInput.text;

        data.balance = 85000;
        data.cash = 115000;

        GameManager.Instance.SaveData();
        Clear();
    }

    public void Cancel()
    {
        gameObject.SetActive(false);
        screen.SetActive(true);
    }

    private bool Check()
    {
        if (nameInput.text == null)
        {
            error.text = "�̸��� Ȯ�����ּ���.";
        }
        else if (idInput.text == null)
        {
            error.text = "ID�� Ȯ�����ּ���.";
        }
        else if (pwInput.text == null)
        {
            error.text = "PW�� Ȯ�����ּ���.";
        }
        else if (pwconformInput.text == null)
        {
            error.text = "PWȮ�ζ��� Ȯ�����ּ���.";
        }
        else if (pwconformInput.text != pwInput.text)
        {
            error.text = "PW�� ��ġ���� �ʽ��ϴ�.";
        }
        else
        {
            Debug.Log("����!");
            return true;
        }
        panel.SetActive(true);
        Clear();
        return false;
    }

    private void Clear()
    {
        nameInput.text = string.Empty;
        idInput.text = string.Empty;
        pwInput.text = string.Empty;
        pwconformInput.text = string.Empty;
    }
}
