using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    public float timer = 0;
    public ParticleSystem particleEffect;
    // Start is called before the first frame update
    void Start()
    {
        // particleEffect.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (timer > 0.1)
        {
            Destroy(this.gameObject);
        }
        
    }
}
