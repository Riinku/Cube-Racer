using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;  //reference the Gameobject to use it in script
    public GameObject controlsMenuUI;

    private void Update()
    {
        //when the esc button is pressed check if it was during game or on pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (FindObjectOfType<GameManager>().isGameEnded() == false)     //checks if the game is ended, so pause menu does not show when u have already lost 
            {
                //game was already paused, so it resumes the game
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    PauseGame();
                }
            }
        }
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; //sets the time scale to 0 meaning it will freeze the time
        GameIsPaused = true;
        FindObjectOfType<AudioManager>().Pause("GameBGM");    //pauses the main theme when pause is pressed
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        controlsMenuUI.SetActive(false);
        Time.timeScale = 1f; //sets the time scale to 1 meaning time will go back to normal
        FindObjectOfType<AudioManager>().Play("GameBGM");    //resumes the main theme when pause is pressed    
        GameIsPaused = false;
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;    //unfreeze the game so on menu screen time is "ON" again
        SceneManager.LoadScene("Menu");
    }

    public void Controls()
    {
        pauseMenuUI.SetActive(false);
        controlsMenuUI.SetActive(true);
        Debug.Log("contorls");
    }

    public void Back()      //when back button is pressed from the controls panel
    {
        pauseMenuUI.SetActive(true);
        controlsMenuUI.SetActive(false);
    }

    public void QuitGame()
    {

        Debug.Log("quitting game");
        Application.Quit();

    }


}
