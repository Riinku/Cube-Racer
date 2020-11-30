using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{



    public Text highScoreText;
    public GameObject youLoseText;
    public GameObject newHighScoreAchieved;

    void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighScore",0).ToString();  
    }
    public void NewHighScore(int IsNewHighScore)        //updates the new high score
    {
        if (IsNewHighScore > PlayerPrefs.GetInt("HighScore",0))     //when the score is a new high score 
        {
            PlayerPrefs.SetInt("HighScore",IsNewHighScore);     //updates the player prefs
            highScoreText.text = IsNewHighScore.ToString();     //updates the highscore displayed in the upper left corner
            youLoseText.SetActive(false);
            newHighScoreAchieved.SetActive(true);
            FindObjectOfType<AudioManager>().Play("HighScore");
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("PlayerDeath");   //plays the player death sound
        }
        
    }





}
