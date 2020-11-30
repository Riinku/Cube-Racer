using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewayForce = 500f;
    public float upwardForce = 500f;
    public GameObject scoreUI;

    private bool gameNotLost = true; //once the game has been lost the players controls are taken away from them

    // Update is called once per frame
    void FixedUpdate()
    {
     
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
          
    if (gameNotLost == true)
    {
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        // if (Input.GetKey("w"))
        // {
        //    rb.AddForce(0, upwardForce * Time.deltaTime, 0, ForceMode.VelocityChange);
        // }
    }

        if(rb.position.x > 8.4 || rb.position.x <-8.4)          //when the player moves too much to the left or right off the panel 
        {
            gameNotLost = false;                                //players movement is disabled 
            FindObjectOfType<GameManager>().GameEnd(rb.position.z);   //Gameend function is called from the game manager and passes the score into the fuction
            rb.useGravity = true;                               //gravity is enabled again so player falls
            scoreUI.SetActive(false);                           //score panel is hidden 
        }

    }
}
