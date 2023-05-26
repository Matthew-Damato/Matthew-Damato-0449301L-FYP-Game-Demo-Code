using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
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

    public int AGrade = 10;
    public int BGrade = 7;
    public int CGrade = 4;

    public string Grade;
    
    public float timeLimit = 110;

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
        timer += Time.deltaTime;
        int t_Hold = (int) timer;

        timerText.text = t_Hold.ToString();
        pointCount = Player.GetComponent<PlayerMovement1>().PointTotal;

        if (timer > timeLimit)
        {
            Player.GetComponent<PlayerMovement1>().enabled = false;
            if (pointCount < CGrade)
            {
                PassOrFail = false;
                
            }
            if (pointCount >= CGrade && pointCount < BGrade)
            {
                points_earned = 10;
                Grade = "C";
            }
            if (pointCount >= BGrade && pointCount < AGrade)
            {
                points_earned = 20;
                Grade = "B";
            }
            if (pointCount >= AGrade)
            {
                points_earned = 20+pointCount;
                Grade = "A";
            }

            GameComplete = true;

        }

    }
}
