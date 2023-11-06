using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject playerGoal;
    private GameObject spawnManager;
    private SpawnManagerX spawnManagerScript;
    public int increasingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.Find("Player Goal");//variable wasn't initialized 
        //Communicate this script to Spawn Manager script
        spawnManager = GameObject.Find("Spawn Manager");
        spawnManagerScript = spawnManager.GetComponent<SpawnManagerX>();
        //increasingSpeed = GameObject.Find("Spawn Manager").GetComponent<SpawnManagerX>().enemySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * increasingSpeed * Time.deltaTime);

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
