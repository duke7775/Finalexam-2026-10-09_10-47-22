using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset = new Vector3(30, 0, 10);

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}