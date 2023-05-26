using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject LeftSpawner;
    public GameObject RightSpawner;

    public GameObject PossibleAns;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float timer;
    public float timer2;

    public int timeToPass = 10;

    public bool FirstTime = true;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        if (FirstTime == true)
        {
            Instantiate(PossibleAns, transform.position, Quaternion.identity);
            FirstTime = false;
        }

        if (timer >= timeToPass)
        {
            Debug.Log("A");
            Instantiate(PossibleAns, transform.position, Quaternion.identity);
            FirstTime = false;
            timer = 0;
        }

        if (timer2 >= 20)
        {
            if (timeToPass > 4)
            {
                timeToPass = timeToPass-1;
                timer2 = 0;
            }
        }
    }
}
