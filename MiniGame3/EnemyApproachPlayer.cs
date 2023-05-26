using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyApproachPlayer : MonoBehaviour
{
    //Script to apprach playerTag
    // Start is called before the first frame update
    public float destroyDelay = 10f;


    public string targetTag = "Player";
    public float moveSpeed = 5f;

    private Transform targetTransform;

    public GameObject shooter;

    void Start()
    {
        // shooter = GameObject.FindGameObjectWithTag("Gun");

        // targetTag = shooter.GetComponent<ProjectileLaunch>().targetTag;
        // GameObject targetObject = GameObject.FindGameObjectWithTag(targetTag);
        // if (targetObject != null)
        // {
        //     targetTransform = targetObject.transform;
        // }
        // Destroy(this.gameObject, destroyDelay);

        GameObject targetObject = GameObject.FindGameObjectWithTag(targetTag);
        targetTransform = targetObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetTransform != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, moveSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
