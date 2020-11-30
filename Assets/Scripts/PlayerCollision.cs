using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public Transform player;
    public GameObject scoreUI;
    

    private void OnCollisionEnter(Collision collisionInfo)          //when the player crashes into an obstacle the following occurs
    {
        //checks if player hit an obstacle by using tha tag obstacle
        if(collisionInfo.collider.tag == "Obstacle")
        {
            Time.timeScale = 0.3f;                  //slowed down time effect
            //Debug.Log("We hit a obstacle, your score is" + player.position.z.ToString("0"));
            movement.enabled = false;       //disables the movement when a collision occurs
            scoreUI.SetActive(false);       //the score panel is hidden, so the score can be highlighted in game lost panel
            FindObjectOfType<GameManager>().GameEnd(player.position.z);       //triggers the GameEnd function from the game manager
        }
    }
}
