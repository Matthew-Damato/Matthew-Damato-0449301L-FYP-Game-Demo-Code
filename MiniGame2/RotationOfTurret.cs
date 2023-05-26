using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationOfTurret : MonoBehaviour
{
    public string targetTag = "Target1";

    public GameObject Gamecontrollingobject;

    public float rotationSpeed = 10f;
    private Transform targetTransform;
    GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetTag = Gamecontrollingobject.GetComponent<QuestionGenerator>().targetObjectForShoot;
        
        GameObject targetObject = GameObject.FindGameObjectWithTag(targetTag);

        targetTransform = targetObject.transform;
        target = GameObject.FindGameObjectWithTag(targetTag);

        if (target != null)
        {
            // Calculate the direction to the target
            Vector3 direction = target.transform.position - transform.position;
            direction.z = 0f;

            // if (direction != Vector3.zero)
            // {
            //     // Calculate the rotation towards the target
            //     Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.forward);

            //     // Smoothly rotate the gameobject towards the target
            //     transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            // }

            // Get Angle in Radians
             float AngleRad = Mathf.Atan2(targetObject.transform.position.y - this.transform.position.y, targetObject.transform.position.x - this.transform.position.x);
             // Get Angle in Degrees
             float AngleDeg = (180 / Mathf.PI) * AngleRad;
             // Rotate Object
             this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);

        }
    }
}
