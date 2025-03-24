using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PopupLogin : MonoBehaviour
{
    [Header("LoginInfo")]
    public InputField _id;
    public InputField _pw;
    public Button LoginBtn;
    public Button SignUPBtn;

    private string id;
    private string pw;

    public GameObject nextPage;
    public GameObject signupPage;

    private void Start()
    {
        SignUPBtn.onClick.AddListener(Signup);
        LoginBtn.onClick.AddListener(Login);
    }

    public void Login()
    {
        this.id = _id.text;
        this.pw = _pw.text;
        GameManager.Instance.LoadData(this.id, ref GameManager.Instance.userData);
        if (GameManager.Instance.userData.ID.Equals(id)&&
            GameManager.Instance.userData.PW.Equals(pw))
        {
            gameObject.SetActive(false);
            nextPage.SetActive(true);
        }
        else
        {
            Debug.Log("¶¯!");
        }
    }

    private void Signup()
    {
        signupPage.SetActive(true);
        gameObject.SetActive(false);
    }
}