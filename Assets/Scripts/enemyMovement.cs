using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{

    public float speed;
    public Transform groundDetect;
    public Transform wallDetect;
    public Transform spikesDetect;
    private bool movingRight = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetect.position, Vector2.down, 1f, LayerMask.GetMask("Ground"));
        RaycastHit2D wallDetect = Physics2D.Raycast(groundDetect.position, Vector2.right, .25f, LayerMask.GetMask("Wall"));
        RaycastHit2D spikesDetect = Physics2D.Raycast(groundDetect.position, Vector2.right, .25f, LayerMask.GetMask("Spikes"));
       

        if (groundInfo.collider == false)
        {

            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {

                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }else if(wallDetect.collider == true)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                
                movingRight = false;
            }
            else
            {

                transform.eulerAngles = new Vector3(0, 0, 0);
               
                movingRight = true;
            }
        }else if(spikesDetect.collider == true)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                
                movingRight = false;
            }
            else
            {

                transform.eulerAngles = new Vector3(0, 0, 0);
               
                movingRight = true;
            }
        }

    }
}
