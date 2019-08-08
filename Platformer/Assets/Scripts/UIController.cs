using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Button TestButton;
    // Start is called before the first frame update
    void Start()
    {
        TestButton.onClick.AddListener(ShowTextLog);
    }

    public void ShowTextLog()
    {
        Debug.Log("Button Clicked!!!!!!!");
        TestButton.interactable = false;
    }
}
