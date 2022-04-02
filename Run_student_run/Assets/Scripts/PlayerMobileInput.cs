using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobileInput : MonoBehaviour
{
    private Rigidbody2D rb;
    private Joystick joystick;
    private Animator anim; 
    private SpriteRenderer sprite;
    private float speedForce = 200f; 
    private float HorizontalMove = 0f;

    private void Start(){

        rb = GetComponent<Rigidbody2D>();
        joystick = FindObjectOfType<Joystick>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update(){
       
        HorizontalMove = joystick.Horizontal;
        rb.velocity = new Vector2(HorizontalMove * speedForce, rb.velocity.y);

        if(Input.GetButtonDown("Jump")){
         rb.velocity = new Vector3(0,200,0);
        }

        updateAnimationState();
   }

   private void updateAnimationState(){
        if(HorizontalMove > 0){
            anim.SetBool("running", true);
            sprite.flipX = false;
        } 
        else if(HorizontalMove < 0){
            anim.SetBool("running", true);
            sprite.flipX = true;
        }
        else{
            anim.SetBool("running", false);
        }
            
   }
}
