using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFlash : MonoBehaviour
{
    public Material flashColor;    // The color to flash
    public float flashDuration = 2.15f;  

    private Renderer objectRenderer;        // The renderer of the object
    private Material originalColor;

    public MeshRenderer MRenderer;


    public ParticleSystem particleEffect;
    // Start is called before the first frame update
    void Start()
    {

        objectRenderer = GetComponent<Renderer>();
        originalColor = objectRenderer.material;

    }

    // Update is called once per frame
    public float timerforparticleeffect = 2.15f;
    void Update()
    {
        timerforparticleeffect += Time.deltaTime;

        if (timerforparticleeffect >= 2)
        {
            Debug.Log("Above2");
            particleEffect.Stop();


            if (particleEffect.isPlaying)
            {
                Debug.Log("Playing");
                particleEffect.Stop();
                // particleEffect.Pause();
                particleEffect.Clear();



                
            }
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        Flash();

        


    }

    

    public void Flash()
    {
        timerforparticleeffect = 0;
        MRenderer.enabled = false;

        if (!particleEffect.isPlaying)
        {
            particleEffect.Play();
        }
        else
        {
            particleEffect.Stop();
        }
        


        
        objectRenderer.material = flashColor;


        Invoke("ResetMaterial", flashDuration);
    }

    private void ResetMaterial()
    {
        objectRenderer.material = originalColor;
        MRenderer.enabled = true;
    }
}
