using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 500;
    private GameObject focalPoint;

    public bool hasPowerup;
    public GameObject powerupIndicator;
    public int powerUpDuration = 5;

    private float normalStrength = 10;
    private float powerupStrength = 25;

    // Turbo boost
    public float turboBoostForce = 15;
    public ParticleSystem turboBoostParticles;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        // Add force to player in direction of the focal point
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(
            focalPoint.transform.forward *
            verticalInput *
            speed *
            Time.deltaTime
        );

        // Set powerup indicator position to beneath player
        powerupIndicator.transform.position =
            transform.position + new Vector3(0, -0.6f, 0);

        // Turbo boost
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(
                focalPoint.transform.forward * turboBoostForce,
                ForceMode.Impulse
            );

            // Play particle effect
            if (turboBoostParticles != null)
            {
                turboBoostParticles.Play();
            }
        }
    }

    // If Player collides with powerup, activate powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);

            hasPowerup = true;
            powerupIndicator.SetActive(true);

            // Start powerup countdown
            StartCoroutine(PowerupCooldown());
        }
    }

    // Coroutine to count down powerup duration
    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(powerUpDuration);

        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    // If Player collides with enemy
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody =
                other.gameObject.GetComponent<Rigidbody>();

            // Direction from player to enemy
            Vector3 awayFromPlayer =
                other.gameObject.transform.position - transform.position;

            if (hasPowerup)
            {
                enemyRigidbody.AddForce(
                    awayFromPlayer * powerupStrength,
                    ForceMode.Impulse
                );
            }
            else
            {
                enemyRigidbody.AddForce(
                    awayFromPlayer * normalStrength,
                    ForceMode.Impulse
                );
            }
        }
    }
}