using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("isGrounded is: " + isGrounded);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            //Debug.Log("isGrounded is: " + isGrounded);
            isGrounded = true;


        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            //Debug.Log("isGrounded is: " + isGrounded);
            isGrounded = false;

        }
    }
}
