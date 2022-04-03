using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jump : MonoBehaviour
{
    public Button button;
    private Rigidbody2D rb;

    private void Start()

    {
        button = GetComponent<Button>();
        rb = GetComponent<Rigidbody2D>();

        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(Pressed);
    }
    void Pressed()
    {
        //jump();
        Debug.Log("Pressed!");
    }

    public void jump()
    {
        rb.velocity = new Vector2(0, 200);
    }
}