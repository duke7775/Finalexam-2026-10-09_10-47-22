using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed = 5f;
    public GameObject playerGoal;

    private Rigidbody enemyRb;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();

        // Find the Player Goal
        if (playerGoal == null)
        {
            playerGoal = GameObject.Find("Player Goal");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerGoal == null)
        {
            return;
        }

        // Set enemy direction towards player goal
        Vector3 lookDirection =
            (playerGoal.transform.position - transform.position).normalized;

        // Move enemy
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }
    }
}