using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public GameObject spawner;

    public int pointStore = 0;

    public bool GameComplete = false;
    public int points_earned;
    public string Grade;
    public bool PassOrFail = true;


    public bool LeftMove = false;
    public bool RightMove = false;
    public bool centerMove = true;

    public static Transform Originalpos;

    public Vector3 OgPos;
    // Start is called before the first frame update
    void Start()
    {
        OgPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }

    public bool Delay = false;
    private float timer;

    // Update is called once per frame
    void Update()
    {
        movement();

        if (Delay = true)
        {
            timer += Time.deltaTime;
            if (timer >= 1)
            {
                ansfield.text = "Next Question";
            }
        }
    }

    private void movement()
    {
        if (centerMove == true)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                //
                Vector3 store = new Vector3(this.transform.position.x-2.5f, this.transform.position.y, this.transform.position.z);
                this.transform.position = store;
                centerMove = false;
                LeftMove = true;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                //
                Vector3 store = new Vector3(this.transform.position.x+ 2.5f, this.transform.position.y, this.transform.position.z);
                this.transform.position = store;
                centerMove = false;
                RightMove = true;
            }
        }
        if (LeftMove == true)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                this.transform.position = OgPos;
                LeftMove = false;
                centerMove = true;
            }
        }
        if (RightMove == true)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                this.transform.position = OgPos;
                RightMove = false;
                centerMove = true;
            }
        }

    }


    public TMP_Text ansfield;

    public GameObject Exp1;
    public GameObject Exp2;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CorrectAns")
        {
            pointStore = pointStore + 1;
            Debug.Log("Do something here");
            GameObject parentObject = collision.gameObject.transform.parent.gameObject;
            Destroy(parentObject);
            this.transform.position = OgPos;
            LeftMove = false;
            RightMove = false;
            centerMove = true;
            Delay = true;
            // ansfield.text = "Next Question";
            Instantiate(Exp1);
        }
        if (collision.gameObject.tag == "IncorrectAns")
        {
            GameComplete = true;
            PostGameUpdate();
            GameObject parentObject = collision.gameObject.transform.parent.gameObject;
            Destroy(parentObject);
            Destroy(spawner);
            this.transform.position = OgPos;
            LeftMove = false;
            RightMove = false;
            centerMove = true;
            Delay = true;
            // ansfield.text = "Next Question";
            Instantiate(Exp2);
        }
    }

    void PostGameUpdate()
    {
        if (pointStore > 30)
        {
            points_earned = pointStore;
            Grade = "A";
        }
        if (pointStore <= 30 && pointStore > 20)
        {
            points_earned = 20;
            Grade = "B";
        }
        if (pointStore <= 20 && pointStore > 15)
        {
            points_earned = 10;
            Grade = "C";
        }
        if (pointStore <= 15)
        {
            PassOrFail = false;
            points_earned = 0;
            Grade = "F";
        }
    }
}
