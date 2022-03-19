using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float lateralMovement = Input.GetAxis("Horizontal") * movementSpeed/20;
        float verticalMovement = Input.GetAxis("Vertical") * movementSpeed/20;

        transform.Translate(new Vector3(lateralMovement,0,verticalMovement));
    }
}
