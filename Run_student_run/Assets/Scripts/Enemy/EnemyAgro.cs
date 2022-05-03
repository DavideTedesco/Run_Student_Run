using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgro : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] private float agroRange;
    [SerializeField] private float moveSpeed;
    private Rigidbody2D enemy;

    // Start is called before the first frame update
    void Start()
    {
     enemy = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        //distance from the player
        float dist2Player = (Mathf.Abs(transform.position.x-player.position.x));
        Debug.Log("distanza: "+ dist2Player);

        if(dist2Player < agroRange && dist2Player > 24.30f)//chase the player
        {
            Chase();
        }
        else//spop chasing player
        
            StopChasing();
        
    }

    private void Chase()
    {
        if(transform.position.x < player.position.x)
        {
            enemy.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(22.76f ,25.46f);
        }
        else if(transform.position.x > player.position.x)
        {
            enemy.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-22.76f ,25.46f);
        }

    }

    private void StopChasing()
    {
        enemy.velocity = new Vector2(0, 0);
    }

}
