using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    // Start is called before the first frame update
    public float destroyDelay = 10f;


    public string targetTag = "Target1";
    public float moveSpeed = 5f;

    private Transform targetTransform;

    public GameObject shooter;

    void Start()
    {
        shooter = GameObject.FindGameObjectWithTag("Gun");

        targetTag = shooter.GetComponent<ProjectileLaunch>().targetTag;
        GameObject targetObject = GameObject.FindGameObjectWithTag(targetTag);
        if (targetObject != null)
        {
            targetTransform = targetObject.transform;
        }
        Destroy(this.gameObject, destroyDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (targetTransform != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, moveSpeed * Time.deltaTime);
        }
    }
}
