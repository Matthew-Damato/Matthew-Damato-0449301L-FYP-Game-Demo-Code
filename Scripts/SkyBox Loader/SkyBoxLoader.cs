using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxLoader : MonoBehaviour
{


    public List<Material> SkyBox;

    // Start is called before the first frame update
    void Start()
    {
        int num_to_generate = Random.Range(0, SkyBox.Count);
        // num_to_generate = 12;

        RenderSettings.skybox=SkyBox[num_to_generate];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
