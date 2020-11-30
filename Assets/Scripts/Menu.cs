using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public GameObject MainMenuUI;
    public GameObject SettingsUI;

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("MenuTheme");
    }

    public void StartGame()    //when the start button is clicked this function is called
    {
        Debug.Log("Start button clicked");
        SceneManager.LoadScene("Endless");
    }

    public void Settings()      //when the settings button is clicked this function is called
    {
        Debug.Log("settings button clicked");
        //SceneManager.LoadScene("Settings");
        MainMenuUI.SetActive(false);
        SettingsUI.SetActive(true);
    }

    public void Quit()          //when the quit button is clicked this function is called
    {
        Debug.Log("Quit button clicked");
        Application.Quit();
    }
    
    public void Credits()      //when the settings button is clicked this function is called
    {
        SceneManager.LoadScene("Credits");
    }

    public void Back()
    {
        MainMenuUI.SetActive(true);
        SettingsUI.SetActive(false);
    }

    public void resetStats()        //resets the high score stats from the playerprefs
    {
            PlayerPrefs.SetInt("HighScore",0);     //updates the player prefs ot zero
            FindObjectOfType<AudioManager>().Play("OMG");
    }

}
