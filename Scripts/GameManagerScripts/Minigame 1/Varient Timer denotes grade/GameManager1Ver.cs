using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager1Ver : MonoBehaviour
{
    //Game manager script:
        // Hold timer
        // Hold point total
        // Hold Game Over condition

    // For the first mini-game, the player must collect as many points as possible in a time limit



    // Start is called before the first frame update

    public float timer = 0;
    public int MistakeCount = 0;

    public int pointCount = 0;

    public int AGradeTime = 60;
    public int BGradeTime = 80;
    public int CGradeTime = 100;

    public string Grade;
    
    public float PointLimit = 30;

    public int points_earned = 0;

    public bool GameComplete = false;

    public bool PassOrFail = true;

    public GameObject Player;

    public Text timerText; 
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        int t_Hold = (int) timer;

        timerText.text = t_Hold.ToString();
        pointCount = Player.GetComponent<PlayerMovement1>().PointTotal;
        bool StopScript = Player.GetComponent<PlayerMovement1>().Varientrule;

        if (StopScript == true)
        {
             if (timer > 101)
            {
                PassOrFail = false;
            }
            if (timer-1 >= BGradeTime && timer-1 <= CGradeTime)
            {
                points_earned = 10;
                Grade = "C";
            }
            if (timer-1 >= AGradeTime && timer-1 <= BGradeTime)
            {
                points_earned = 20;
                Grade = "B";
            }
            if (timer-1 < AGradeTime)
            {
                points_earned = 30;
                Grade = "A";
            }
            GameComplete = true;
            Debug.Log("DONE!");
        }
        else
        {
            timer += Time.deltaTime;
        }

        // if (pointCount >= PointLimit)
        // {
        //     if (timer > 101)
        //     {
        //         PassOrFail = false;
        //     }
        //     if (timer-1 >= BGradeTime && timer-1 <= CGradeTime)
        //     {
        //         points_earned = 10;
        //         Grade = "C";
        //     }
        //     if (timer-1 >= AGradeTime && timer-1 <= BGradeTime)
        //     {
        //         points_earned = 20;
        //         Grade = "B";
        //     }
        //     if (timer-1 < AGradeTime)
        //     {
        //         points_earned = 30;
        //         Grade = "A";
        //     }
        //     GameComplete = true;
        //     Debug.Log("DONE!");
        // }

        // if (timer > timeLimit)
        // {
        //     Player.GetComponent<PlayerMovement1>().enabled = false;
        //     if (pointCount < CGrade)
        //     {
        //         PassOrFail = false;
                
        //     }
        //     if (pointCount >= CGrade && pointCount < BGrade)
        //     {
        //         points_earned = 10;
        //         Grade = "C";
        //     }
        //     if (pointCount >= BGrade && pointCount < AGrade)
        //     {
        //         points_earned = 20;
        //         Grade = "B";
        //     }
        //     if (pointCount >= AGrade)
        //     {
        //         points_earned = 20+pointCount;
        //         Grade = "A";
        //     }

        //     GameComplete = true;

        // }

    }
}
