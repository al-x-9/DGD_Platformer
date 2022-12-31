using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileMovement : MonoBehaviour
{
    //DEFINE A VARIALBE THAT SETS THE SPEED OF THE GAME OBJECT
    public float speed;
    public Vector3 projectileDirection;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += projectileDirection * speed * Time.deltaTime; 

      
        //Time.deltaTime IS USED TO ENSURE THAT THE ACTION IS CONSISTENT REGARDLESS OF THE FRAME RATE. 

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

   
}
