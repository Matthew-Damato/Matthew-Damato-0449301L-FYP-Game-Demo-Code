using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerDestroy1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject Soundbyte;

    void OnCollisionEnter(Collision collision) 
    {
        Debug.Log("Collided 3");
        if (collision.gameObject.tag == "Player" ) {
            Debug.Log("Collided 4");
            Destroy(gameObject);
            Instantiate(Soundbyte);
        }
 
    }
}
