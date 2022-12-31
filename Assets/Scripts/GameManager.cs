using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //PUBLIC VARIABLES//

    //DEFINE A VARIABLE THAT WILL DEFINE THE playerObject
    public GameObject playerObject;
    //DEFINE A VARIABLE THAT WILL DEFINE THE gameOverScreen
    public GameObject gameOverScreen;
    //USED THROUGHOUT THIS SCRIPT TO DISPLAY THE SCORE
    public Text scoreText;
    public int totalPoints;
    //DEFINE A VARIABLE THAT WILL DETERMINE WHETHER OR NOT THE GAME IS OVER
    private bool isGameOver;
    private int score;
  

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        //SET THE SCORE TO ZERO
        score = 0;
        //DISPLAY THE SCORE USING THE scoreText TEXT OBJECT
        scoreText.text = score.ToString() + " OF " + totalPoints;

    }

    // Update is called once per frame
    void Update()
    {
        //IF THE GAME IS OVER AND THE R KEY IS PRESSED THEN...
        if (isGameOver == true && Input.GetKeyDown(KeyCode.R))
        {

            //LOAD THE SCENE CALLED SampleScene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            //SET THE gameOver VARIABLE TO FALSE
            isGameOver = false;

        }

        if(totalPoints == score)
        {

            //LOAD THE NEXT SCENE
     
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString() + " OF " + totalPoints;
        
    }

    public void GameOver()
    {
        //Debug.Log("GAME OVER FUNCTION IS RUNNING");

        //ACTIVATE THE GAME OVER SCREEN
        gameOverScreen.SetActive(true);

        //DEACTIVATE THE PLAYER OBJECT
        playerObject.SetActive(false);

        //SET THE gameOver VARIABLE TO TRUE
        isGameOver = true;

      
    }

}
