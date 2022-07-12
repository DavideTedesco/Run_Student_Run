using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jump : MonoBehaviour
{
    public Button button;


    private void Start()

    {
        button = GetComponent<Button>();

        //Button btn = button.GetComponent<Button>();
        //btn.onClick.AddListener(Pressed);
    }
    void Pressed()
    {
        Debug.Log("Pressed!");
    }

}