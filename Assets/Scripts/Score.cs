using UnityEngine;
using UnityEngine.UI; 

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;

    public GameObject scoreUI;
    

    // Update is called once per frame
    void Update()
    {
        scoreText.text = player.position.z.ToString("0");
        
    }

    public void turnOffScoreUI()
    {
        scoreUI.SetActive(false);
    }





}
