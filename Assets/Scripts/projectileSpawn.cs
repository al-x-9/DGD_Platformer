using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileSpawn : MonoBehaviour
{
    //DEFINE A VARIABLE FOR THE GAME OBJECT WE INTEND TO SPAWN
    public GameObject prefab;

    //DEFINE A VARIABLE FOR HOW OFTEN THE GAME OBJECT IS SPAWNED
    public float spawnRate;

    //DEFINE A VARIABLE FOR HOW FAST THE SPAWNED OBJECT IS MOVES
    public float projectileSpeed;


    //DEFINE A VARIABLE FOR A TIMER FOR THE SPAWNER
    private float spawnCounter;

    //DEFINE A VARIABLE FOR THE SCRIPT CALLED ENDLESS_ENEMY_MOVEMENT_01
    projectileMovement pMov;

    public enum spawnDirection { up, down, left, right };
    public spawnDirection sDirection;
    
   

    // Start is called before the first frame update
    void Start()
    {

        //ASSIGN THE ENDLESS_ENEMY_MOVMENT_01 SCRIPT TO OUR EEM01 VARIABLE
        pMov = prefab.GetComponent<projectileMovement>();
      

    }

    // Update is called once per frame
    void Update()
    {
        pMov.speed = projectileSpeed;

        if (sDirection == spawnDirection.up)
        {

            pMov.projectileDirection = Vector3.up;
        }
        else if (sDirection == spawnDirection.down)
        {

            pMov.projectileDirection = Vector3.down;

        }
        else if (sDirection == spawnDirection.left)
        {
            pMov.projectileDirection = Vector3.left;
        }
        else if (sDirection == spawnDirection.right)
        {
            pMov.projectileDirection = Vector3.right;
        }
        

        //IF spawnCounter IS LESS THAN OR EQUAL TO ZERO THEN...
        if (spawnCounter <= 0)
        {
            //CREATE A CLONE OF OUR ENEMY(PREFAB) USING INSTATNTIATE FUNCTION. WE WANT TO ASSIGN THE CLONE TO A GAMEOBJECT SO THAT WE CAN ASSIGN IT A RANDOM POSITION IN THE GAME SPACE (BELOW).
            GameObject enemy = Instantiate(prefab, transform.position, Quaternion.identity);


            //RESET THE SPAWN COUNTER
            spawnCounter = spawnRate;
        }
        //IF THE CONDITION ABOVE IS NOT TRUE THEN...
        else
        {
            //SUBTRACT Time.deltaTime FROM spawnCounter. SERVES AS A COUNTDOWN TIMER FOR THE SPAWN RATE.
            spawnCounter -= Time.deltaTime;
        }


    }
}
