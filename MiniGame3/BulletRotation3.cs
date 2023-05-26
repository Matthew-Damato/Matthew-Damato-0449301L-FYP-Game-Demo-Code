using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRotation3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float rotateSpeed  = 50.0f;

    // Update is called once per frame
    void Update()
    {
        // transform.Rotate(Vector3.up * degreesPerSecond*Time.deltaTime, Space.Self); 
        
        transform.Rotate(Vector3.right, rotateSpeed * Time.deltaTime);
        // rigidbody.isKinematic = true;
    }
}
