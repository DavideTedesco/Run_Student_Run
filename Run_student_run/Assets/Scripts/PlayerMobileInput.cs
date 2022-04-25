using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMobileInput : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;
    private Joystick joystick;
    private Animator anim; 
    private SpriteRenderer sprite;
    private float speedForce = 200f; 
    private float HorizontalMove = 0f;
    private float VerticalMove = 0f;
    public GameObject pauseMenuPanel;
    public GameObject pauseButton;
    
    private enum MovementState{idle, runnig, jumping, falling, doubleJump};

    private int numberOfJump;

    private void Start(){

        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
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

        MovementState state;

        if(HorizontalMove > 0){
            state = MovementState.runnig;
            sprite.flipX = false;
        } 
        else if(HorizontalMove < 0){
            state = MovementState.runnig;
            sprite.flipX = true;
        }
        else{
            state = MovementState.idle;
        }

        if(rb.velocity.y > .001f && numberOfJump == 0)
        {
            state = MovementState.jumping;
        }
        else if(rb.velocity.y > .001f && numberOfJump == 1)
        {
            state = MovementState.doubleJump;
        }
        else if(rb.velocity.y < -.001f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state",(int)state);
        
    }

    public void jump()
    {
        if(IsGrounded())
        {
            numberOfJump = 0;
            rb.velocity = new Vector2(rb.velocity.x, 200);
        }
        else if(numberOfJump < 1)
        {
            numberOfJump++;
            rb.velocity = new Vector2(rb.velocity.x, 300);
        }
            
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

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    public void backToIdle()
    {
         anim.SetTrigger("idle");
    }

}
