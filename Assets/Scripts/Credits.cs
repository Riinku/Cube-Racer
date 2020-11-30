using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("Application has quit");
        Application.Quit();
    }

    public void MainMenu()
    {
        Debug.Log("Main menu clicked");
        SceneManager.LoadScene("Menu");
    }

}
