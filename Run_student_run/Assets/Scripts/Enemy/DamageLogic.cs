using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageLogic : MonoBehaviour
{

    [SerializeField] private LayerMask killer;
    [SerializeField] private GameObject damagePoint;
    [SerializeField] private GameObject castPos;
    [SerializeField] private GameObject enemy;
    private GameObject objEnemy;
     private BoxCollider2D collider;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        objEnemy = GetComponent<GameObject>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(BeingKilled())
        {
            anim.SetTrigger("death");
            Destroy(damagePoint);
            //Destroy(objEnemy);
            //Destroy(castPos);
        }
    }
    void DestroyEnemy()
    {
        Destroy(enemy);
    }

    private bool BeingKilled()
    {
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size , 0f, Vector2.up, .1f, killer);
    }
}
