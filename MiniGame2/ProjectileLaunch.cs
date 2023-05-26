using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunch : MonoBehaviour
{

    // public GameObject projectilePrefab;
    // public float launchSpeed = 10f;
    // Start is called before the first frame update

    public GameObject Gamecontrollingobject; 

    public float launchSpeed = 20f;
    public GameObject Bullet;

    public string targetTag = "Target1";


    public GameObject targetObject;

    void Start()
    {
        
    }

    public float shootTimer = 0;

    // Update is called once per frame
    void Update()
    {
        

        targetTag = Gamecontrollingobject.GetComponent<QuestionGenerator>().targetObjectForShoot;
        bool tempcheckifgamecompleteornot = Gamecontrollingobject.GetComponent<QuestionGenerator>().GameComplete;


        bool checkiftimershouldstart = Gamecontrollingobject.GetComponent<QuestionGenerator>().startTimer;

        if (tempcheckifgamecompleteornot == true)
        {
            // Destroy(this);
        }


        bool shootBullet = false;

        if (checkiftimershouldstart == true)
        {
            shootTimer += Time.deltaTime;
            GameObject launchedObject = Instantiate(Bullet, transform.position, Quaternion.identity);
            Rigidbody launchedObjectRigidbody = launchedObject.GetComponent<Rigidbody>();
        }
        if (checkiftimershouldstart == false)
        {
            shootTimer = 0;
        }
            // if (shootBullet == true)
            // {
                
            // }
                
        
    }
}
