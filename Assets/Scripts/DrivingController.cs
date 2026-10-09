using UnityEngine;

public class DrivingController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float groundY = 0f;

    public Transform playerCamera;
    public Vector3 cameraOffset = new Vector3(0f, 5f, -8f);
    public float cameraSmoothSpeed = 5f;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized;

        transform.position += movement * moveSpeed * Time.deltaTime;

        Vector3 position = transform.position;
        position.y = groundY;
        transform.position = position;
    }

    void LateUpdate()
    {
        if (playerCamera != null)
        {
            Vector3 targetPosition = transform.position + cameraOffset;

            playerCamera.position = Vector3.Lerp(
                playerCamera.position,
                targetPosition,
                cameraSmoothSpeed * Time.deltaTime
            );

            playerCamera.LookAt(transform.position);
        }
    }
}