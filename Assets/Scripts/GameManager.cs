using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;
    public float restartDelay = 1f;
    public GameObject levelFailUI;      //UI for if theplayer crashes into obstacle or falls off the sides of the ground platforms
    public Text finalScoreText;         //Text for the final score of the player  
    
    public bool isGameEnded()
    {
        return gameEnded;
    }

    public void GameEnd(float finalScoreFloat)
    {
        if (gameEnded == false)
        {
            FindObjectOfType<AudioManager>().Stop("GameBGM");
            
            gameEnded = true;
            Debug.Log("GAME OVER");
            int finalScore = (int) finalScoreFloat;     //converts the float valaue of final score to int
            levelFail(finalScore);                  //calls level fail fucntion passing the final score
            StartCoroutine(waitForSpacePress());        
        }
    }


    public void levelFail(int finalScore)
    {
        Debug.Log("you have crashed");
        finalScoreText.text = finalScore.ToString();
        levelFailUI.SetActive(true);
        FindObjectOfType<HighScore>().NewHighScore(finalScore);     //sends the high score to be updated
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    IEnumerator waitForSpacePress()     //while the space key is not pressed game will be stuck inside a while loop
    {
        bool endFlag = false;   
        while (endFlag == false)
            {               
                if (Input.GetKey(KeyCode.Space))
                {
                    endFlag = true;
                }
                yield return null;
            }
        restart();    
    }

}
