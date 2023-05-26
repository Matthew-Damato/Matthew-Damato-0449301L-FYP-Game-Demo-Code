using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter3Seconds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float delay = 5f;
    // Update is called once per frame
    void Update()
    {
        Debug.Log("I LIVED!");
        Destroy(this.gameObject, delay);
    }
}
