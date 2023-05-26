using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class AnswerGenerator : MonoBehaviour
{
    public float timer;

    public bool multiplication = true;

    public GameObject Spawner;
    public Transform Spawnlocation; 

    public GameObject Left;
    public GameObject Right;

    public TMP_Text LeftText;
    public TMP_Text RightText;
    public TMP_Text  Questiontext;

    public ParticleSystem LeftParticle;
    public ParticleSystem RightParticle;

    public string questionText;
    // Start is called before the first frame update
    void Start()
    {
        Spawnlocation = GameObject.FindWithTag("Spawner").transform;
        transform.position = Spawnlocation.position;
        GameObject TObj = GameObject.FindWithTag("AnswerText");
        Questiontext = TObj.GetComponent<TMP_Text>();
    }


    public bool onetime = true;
    // Update is called once per frame
    void Update()
    {
        string temptitle = Questiontext.text;



        timer += Time.deltaTime;
        if (timer >= 1)
        {
            transform.position += Vector3.forward * -10 * Time.deltaTime;
            if (string.IsNullOrEmpty(temptitle))
            {
                Questiontext.text = displayNo3.ToString();
            }
            if (temptitle == "Next Question")
            {
                Questiontext.text = displayNo3.ToString();
            }
        }
        if (onetime == true)
        {
            QuestionGenerator();
            onetime = false;
        }
        
    }


    private void QuestionGenerator()
    {
        //Going for mathamatical questions:

        if (multiplication == true)
        {
            multiplicationNumbers();
        }

    }


    public int displayNo1;
    public int displayNo2;
    public int displayNo3;

    void multiplicationNumbers()
    {
        int NumberToReach = Random.Range(15,500);

        displayNo3 = NumberToReach;

        int[] factors = FindFactors(NumberToReach);     

        int tempchoice = Random.Range(0,2);

        displayNo1 = factors[0];
        displayNo2 = factors[1];
        displayNo3 = NumberToReach;

        if (tempchoice == 0)
        {
            LeftText.text =  factors[0] + " multiplied by " + factors[1];
            RightText.text =  factors[0] + " multiplied by " + Random.Range(factors[0], factors[1]);
            Left.tag = "CorrectAns";
            Right.tag = "IncorrectAns";
        }
        else
        {
            RightText.text =  factors[0] + " multiplied by " + factors[1];
            LeftText.text =  factors[0] + " multiplied by " + Random.Range(factors[0], factors[1]);
            Right.tag = "CorrectAns";
            Left.tag = "IncorrectAns";
        }



    }

    public int displayNo4;
    
    static int[] FindFactors(int n) 
    {
        int factorsnumber = Random.Range(2,4);
        int[] factors = new int[factorsnumber];
        
        int temphold = DivideBy2(n);
        float StartingNum = Random.Range(2, temphold/2);
        int StartNum = (int)StartingNum;

        for (int i = StartNum; i <= temphold; i++) {
            Debug.Log("looping");
            if (n % i == 0 && i != 2) {
                factors[0] = i;
                factors[1] = n / i;
                return factors;
            }
            Debug.Log(i);
        }
        
        return null;
    }

    static int DivideBy2(int num)
    {
        int result = (num % 2 == 0) ? num / 2 : (num / 2) + 1;
        Debug.Log(result);
        return result;
    }
}
