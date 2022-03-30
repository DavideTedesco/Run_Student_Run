using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobileInput : MonoBehaviour
{
    private Rigidbody2D rb;
    public Joystick joystick;
    private float speedForce = 200f; 

    private void Start(){

        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        joystick = FindObjectOfType<Joystick>();
        float HorizontalMove = joystick.Horizontal;
       rb.velocity = new Vector2(HorizontalMove * speedForce, rb.velocity.y);

       if(Input.GetButtonDown("Jump")){
         rb.velocity = new Vector3(0,200,0);
     }
   }
}
