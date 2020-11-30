using UnityEngine;
using UnityEngine.SceneManagement;



public class Controls : MonoBehaviour
{
 
    public void Back()
    {
        Debug.Log("going back");
        SceneManager.LoadScene("Menu");
    }


}
