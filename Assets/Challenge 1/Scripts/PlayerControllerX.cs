
using UnityEngine;

public class PlayerControllerChallenge1 : MonoBehaviour
{
    public float speed = 15f;
    public float turnSpeed = 45f;
    public float rotationSpeed = 120f;

    private float horizontalInput;
    private float verticalInput;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        transform.Rotate(Vector3.up * horizontalInput * turnSpeed * Time.deltaTime);

        transform.Rotate(Vector3.right * verticalInput * rotationSpeed * Time.deltaTime);
    }
}
