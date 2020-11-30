using UnityEngine;
using UnityEngine.SceneManagement;
public class Settings : MonoBehaviour
{



    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }

    public void resetStats()        //resets the high score stats from the playerprefs
    {
            PlayerPrefs.SetInt("HighScore",0);     //updates the player prefs ot zero
            FindObjectOfType<AudioManager>().Play("OMG");
    }
    


}
