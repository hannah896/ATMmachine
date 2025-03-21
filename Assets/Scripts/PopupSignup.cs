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
    public Button SignupPanel;
    public Button Cancel;

    public void Signup()
    {
        if ((nameInput == null) || (idInput == null) || (pwInput == null) || (pwconformInput == null) || (pwconformInput != pwInput))
        {
            panel.SetActive(true);
        }

        UserData data = GameManager.Instance.userData;

        data.userName = nameInput.text;

        data.ID = idInput.text;
        data.PW = pwInput.text;

        data.balance = 85000;
        data.cash = 115000;

        GameManager.Instance.SaveData();
    }
}
