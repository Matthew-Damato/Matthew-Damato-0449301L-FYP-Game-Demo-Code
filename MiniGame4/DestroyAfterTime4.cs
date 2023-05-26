using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime4 : MonoBehaviour
{
    public float DestroyDelay = 1.3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, DestroyDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
