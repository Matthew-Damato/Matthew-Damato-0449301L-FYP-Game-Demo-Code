using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerSpawner : MonoBehaviour
{
    //Answers to be spawned
    public GameObject AnswerPrefab;

    //Total number to be spawned
    public int numAnswers;

    //Distance from every other Answer
    public float minDistance;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        var NumOfAnswersSpawned = GameObject.FindGameObjectsWithTag("Answer");

        //Create a for loop to instanciate the number of Answers.
        while (NumOfAnswersSpawned.Length < numAnswers)
        {
            //create a function to handle the spawning of gameobjects
            SpawnObjects();

            NumOfAnswersSpawned = GameObject.FindGameObjectsWithTag("Answer");
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
                    //Answer
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

        // Instantiate the Answer at the generated position
        GameObject Answer = Instantiate(AnswerPrefab, spawnPosition, Quaternion.identity);
        Answer.tag = "Answer";
    }
}
