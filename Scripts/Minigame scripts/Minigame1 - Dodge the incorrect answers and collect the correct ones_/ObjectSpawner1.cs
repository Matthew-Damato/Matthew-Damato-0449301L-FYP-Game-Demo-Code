using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner1 : MonoBehaviour
{
    //Obstacles to be spawned
    public GameObject obstaclePrefab;

    //Total number to be spawned
    public int numObstacles;

    //Distance from every other obstacle
    public float minDistance;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        var NumOfObstaclesSpawned = GameObject.FindGameObjectsWithTag("Obstacle");

        //Create a for loop to instanciate the number of obstacles.
        while (NumOfObstaclesSpawned.Length < numObstacles)
        {
            //create a function to handle the spawning of gameobjects
            SpawnObjects();

            NumOfObstaclesSpawned = GameObject.FindGameObjectsWithTag("Obstacle");
        }

    }

    private void SpawnObjects()
    {
        Vector3 spawnPosition;
        bool positionFound = false;

        //Next use a do while loop to genetate random positions until an empty space is found
        do
        {
            // Generate a random position within the boundaries of the spawner object
            spawnPosition = new Vector3(Random.Range(transform.position.x - transform.localScale.x / 2, transform.position.x + transform.localScale.x / 2),
                                        Random.Range(transform.position.y - transform.localScale.y / 2, transform.position.y + transform.localScale.y / 2),
                                        Random.Range(transform.position.z - transform.localScale.z / 2, transform.position.z + transform.localScale.z / 2));

            // Check if there are any colliders within the specified minimum distance of the generated position
            Collider[] colliders = Physics.OverlapSphere(spawnPosition, minDistance);
            positionFound = true;
            foreach (Collider collider in colliders)
            {
                //Tags to be checked: 
                    //Obstacle
                    //Player
                    //walls
                    //goals
                if (collider.gameObject.tag == "Obstacle" || collider.gameObject.tag == "Walls" || collider.gameObject.tag == "Player" || collider.gameObject.tag == "Answer")
                {
                    positionFound = false;
                    break;
                }
            }
        } while (!positionFound);

        // Instantiate the obstacle at the generated position
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        obstacle.tag = "Obstacle";
    }
}
