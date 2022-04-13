using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMobileInput : MonoBehaviour
{
    private Rigidbody2D rb;
    private Joystick joystick;
    private Animator anim; 
    private SpriteRenderer sprite;
    private float speedForce = 200f; 
    private float HorizontalMove = 0f;
    private float VerticalMove = 0f;
    public GameObject pauseMenuPanel;
    public GameObject pauseButton;

    private void Start(){

        rb = GetComponent<Rigidbody2D>();
        joystick = FindObjectOfType<Joystick>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        //pauseMenuPanel = GetComponent<GameObject>();
    }

   
    void Update(){
       
        HorizontalMove = joystick.Horizontal;
        rb.velocity = new Vector2(HorizontalMove * speedForce, rb.velocity.y);
        VerticalMove = joystick.Vertical;


        if (VerticalMove > .8f)
        {
            rb.velocity = new Vector2(0, 150);
        }

        updateAnimationState();
   }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Books"))
            Destroy(other.gameObject);
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

        //if (VerticalMove > 0)
        //{
        //    anim.SetBool("jumping", true);
        //    sprite.flipY = false;
        //}
       
        //else
        //{
        //    anim.SetBool("standing", false);
        //}
    }

    public void jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 200);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuPanel.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuPanel.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void ReplayGame()
    {
        Time.timeScale = 1;
        pauseMenuPanel.SetActive(false);
        pauseButton.SetActive(true);

    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("AllYears");
    }

    public void GoToLevel()
    {
        //Debug.Log(currentLevel.ToString());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}
