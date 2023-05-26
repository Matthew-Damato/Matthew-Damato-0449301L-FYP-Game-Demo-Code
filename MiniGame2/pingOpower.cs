using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pingOpower : MonoBehaviour
{
    public ParticleSystem particleEffect;
    public GameObject gameobjectccontainingcontroller; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private bool isColliding = false;

    private void OnCollisionStay(Collision collision)
    {
        // Check if the other object has a particular tag
        if (collision.gameObject.CompareTag("ChargeBeam"))
        {
            isColliding = true;
        }
        else
        {
            isColliding = false;
        }
    }

    public GameObject EndEffect;
    public bool gameiscompleted = false;
    public float delay = 0.5f; 
    // Update is called once per frame
    void Update()
    {
        gameiscompleted = gameobjectccontainingcontroller.GetComponent<QuestionGenerator>().GameComplete;

        if (gameiscompleted == true)
        {
            Instantiate(EndEffect, transform.position, transform.rotation);
            Destroy(this.gameObject, delay);
        }


        // if (isColliding)
        // {
        //     // Perform the desired action
        //     Debug.Log("Object is colliding with object with 'OtherTag' tag");
        //     particleEffect.Play();
        //     // Do something here

        // }
        // else
        // {
        //     particleEffect.Stop();
        // }
    }


}
