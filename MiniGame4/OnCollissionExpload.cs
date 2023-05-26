using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollissionExpload : MonoBehaviour
{
    public ParticleSystem Particle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("HELLO");
            Particle.Play();
        }
        else
        {
            Particle.Stop();
        }
        
    }
}
