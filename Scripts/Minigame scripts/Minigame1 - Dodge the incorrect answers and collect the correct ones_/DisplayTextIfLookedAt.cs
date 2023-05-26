using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTextIfLookedAt : MonoBehaviour
{
    public LayerMask mask;

    public Camera PCamera;

    float maxDistance = 10;

    private List<GameObject> detectedObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        detectedObjects.Clear();

        RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, maxDistance, mask);

        foreach (RaycastHit hit in hits)
        {
            //event
        }
    }

}
