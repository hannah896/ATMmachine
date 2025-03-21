using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public GameObject screen;
    
    public Button btn;

    private void OnValidate()
    {
        if (btn == null) btn = GetComponent<Button>();
        btn.onClick.AddListener(Act);
    }

    private void Act()
    {
        transform.parent.gameObject.SetActive(false);
        screen.SetActive(true);
    }
}