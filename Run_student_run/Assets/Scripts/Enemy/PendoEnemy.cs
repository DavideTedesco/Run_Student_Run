using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendoEnemy : MonoBehaviour
{   
    const string LEFT = "left";
    const string RIGHT = "right";
    [SerializeField]Transform castpos; 
    [SerializeField]float baseCastDistance; 
    string facingDirection; 
    Rigidbody2D rb;
     private Animator anim;
    Vector3 baseScale;
    [SerializeField]float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {   
        facingDirection = RIGHT;
        rb = GetComponent<Rigidbody2D>();
        baseScale = transform.localScale;
    }

    void update()
    {
        updateAnimationState();
    }
     private void updateAnimationState(){
        
        if(rb.velocity.x > 0 || rb.velocity.x < 0)
        {
             anim.SetBool("running", true);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        if(facingDirection == LEFT)
            {
                rb.velocity = new Vector3(-moveSpeed, rb.velocity.y);
            } 
            else 
            {
                rb.velocity = new Vector3(moveSpeed, rb.velocity.y);
            }
        

        if(IsHittingWall() || OnTheEdge())
        {
            if(facingDirection == LEFT)
            {
                ChangeFacingDirection(RIGHT);
            } 
            else if(facingDirection == RIGHT)
            {
                ChangeFacingDirection(LEFT);
            }
        }

    }

    void ChangeFacingDirection(string newDirection)
    {
        Vector3 newScale = baseScale;

        if(newDirection == LEFT)
        {
            newScale.x = -baseScale.x;       
        }
        else
        {
            newScale.x = baseScale.x;
        }
        
        transform.localScale = newScale;
        facingDirection = newDirection;

    }
    private bool IsHittingWall()
    {
        bool val = false;
        float castDist = baseCastDistance;

        if(facingDirection == LEFT)
        {
            castDist = -baseCastDistance;
        }

        Vector3 targetPos = castpos.position;
        targetPos.x += castDist;

        Debug.DrawLine(castpos.position, targetPos, Color.red);
        if(Physics2D.Linecast(castpos.position, targetPos, 1 << LayerMask.NameToLayer("Ground")))
        {
            val = true;
        }
        else
        {
            val = false;
        }

        return val;
    }

    private bool OnTheEdge()
    {
        bool val = true;
        float castDist = baseCastDistance;

        Vector3 targetPos = castpos.position;
        targetPos.y -= castDist;

        Debug.DrawLine(castpos.position, targetPos, Color.blue);
        if(Physics2D.Linecast(castpos.position, targetPos, 1 << LayerMask.NameToLayer("Ground")))
        {
            val = false;
        }
        else
        {
            val = true;
        }

        return val;
    }

    public void die()
    {
        rb.bodyType = RigidbodyType2D.Static;
    }
}
