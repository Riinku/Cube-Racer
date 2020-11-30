using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    // Update is called once per frame

    private void Start()
    {
        transform.position = player.position + offset;
    }

    void Update()
    {

        transform.position = player.position + offset;

        transform.rotation = Quaternion.Euler(0,0, -player.position.x);


    }
}
