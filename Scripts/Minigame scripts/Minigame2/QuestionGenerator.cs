using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class QuestionGenerator : MonoBehaviour
{
    public int points_earned = 0;
    public bool GameComplete = false;
    public bool PassOrFail = true;
    public string Grade;

    public string targetObjectForShoot = "Gun";


    //List of questions and answers 
    public List<string> Question1 = new List<string>();
    public List<string> Question2 = new List<string>();
    public List<string> Question3 = new List<string>();
    public List<string> Question4 = new List<string>();
    public List<string> QuestionCorrect = new List<string>();

    public List<string> Answers = new List<string>();

    public TMP_Text Q1Text;
    public TMP_Text Q2Text;
    public TMP_Text Q3Text;
    public TMP_Text Q4Text;

    public TMP_Text AnsText; 


    public ParticleSystem Button1;
    public ParticleSystem Button2;
    public ParticleSystem Button3;
    public ParticleSystem Button4;




    public int TimeToAns = 10;
    public int PlayerHP = 4;
    public int NumberQuestionsToAnswer = 10;

    private int Q1Random = 0;
    private int Q2Random = 0;
    private int Q3Random = 0;
    private int Q4Random = 0;

    private int AnsRandom = 0;

    // Start is called before the first frame update


    public Button Q1;
    public Button Q2;
    public Button Q3;
    public Button Q4;
    private int buttonClickedNumber;
    void Start()
    {
        // Button Q1Btn = Q1.GetComponent<Button>();
        Q1.onClick.AddListener(TaskOnClick1);

        // Button Q2Btn = Q2.GetComponent<Button>();
        Q2.onClick.AddListener(TaskOnClick2);

        // Button Q3Btn = Q3.GetComponent<Button>();
        Q3.onClick.AddListener(TaskOnClick3);

        // Button Q4Btn = Q4.GetComponent<Button>();
        Q4.onClick.AddListener(TaskOnClick4);
    }

    private bool refreash = true;


    public float timer;

    public bool startTimer = false;
    public float timetakenpershot;
    public GameObject GunShooter;
    public float Beamduration = 0.25f;


    public GameObject Health0;
    public GameObject Health1;
    public GameObject Health2;
    public GameObject Health3;
    public GameObject Health4;
    // Update is called once per frame
    void Update()
    {
        timetakenpershot = GunShooter.GetComponent<ProjectileLaunch>().shootTimer;

        if (timetakenpershot > Beamduration)
        {
            startTimer = false;
        }
        
        if (PlayerHP != 0 && NumberQuestionsToAnswer != 0)
        {
            timer += Time.deltaTime;
            QuestionLoad();
        }



        if (PlayerHP == 4)
        {
            Health4.SetActive(true);
            Health3.SetActive(false);
            Health2.SetActive(false);
            Health1.SetActive(false);
            Health0.SetActive(false);
        }

        if (PlayerHP == 3)
        {
            Health3.SetActive(true);
            Health4.SetActive(false);
            Health2.SetActive(false);
            Health1.SetActive(false);
            Health0.SetActive(false);
        }

        if (PlayerHP == 2)
        {
            Health2.SetActive(true);
            Health4.SetActive(false);
            Health3.SetActive(false);
            Health1.SetActive(false);
            Health0.SetActive(false);
        }

        if (PlayerHP == 1)
        {
            Health1.SetActive(true);
            Health4.SetActive(false);
            Health3.SetActive(false);
            Health2.SetActive(false);
            Health0.SetActive(false);
        }

        if (PlayerHP == 0)
        {
            Health0.SetActive(true);
            Health4.SetActive(false);
            Health3.SetActive(false);
            Health2.SetActive(false);
            Health1.SetActive(false);
        }


        

        if (PlayerHP == 0 || NumberQuestionsToAnswer == 0)
        {
            GameComplete = true;
            if (PlayerHP == 4)
            {
                points_earned = 35;
                Grade = "A";
            }
            if (PlayerHP == 3)
            {
                points_earned = 25;
                Grade = "B";
            }
            if (PlayerHP == 2)
            {
                points_earned = 15;
                Grade = "C";
            }
            if (PlayerHP == 1)
            {
                points_earned = 5;
                Grade = "F";
                PassOrFail =  false;
            }
            if (PlayerHP == 0)
            {
                PassOrFail =  false;
            }
            
        }



        




        
    }





    public int correctAnswer;
    private int SelectedAnswer;


    private bool Wait = false;

    void QuestionLoad()
    {
        if (refreash == true)
        {
            QandAGenerate();
            timer = 0;
        }   

        //Create a series of buttons, and a correct answer.
        if (SelectedAnswer == correctAnswer)
        {
            if (Wait == false)
            {
                NumberQuestionsToAnswer = NumberQuestionsToAnswer - 1;
                Wait = true;
                SelectedAnswer = 0;
                refreash = true;
            }
            
        }
        if (SelectedAnswer != 0 && SelectedAnswer != correctAnswer)
        {
            if (Wait == false)
            {
                PlayerHP = PlayerHP-1;
                Wait = true;
                SelectedAnswer = 0;
                refreash = true;
            }
            

        }


        if (timer >= TimeToAns)
        {
            refreash = true;
            PlayerHP = PlayerHP-1;
        }
    }

    
    void TaskOnClick1()
    {
        Debug.Log("You have clicked button 1!");
        targetObjectForShoot = "Target1";
        startTimer = true;
        SelectedAnswer = 1;
    }
    void TaskOnClick2()
    {
        Debug.Log("You have clicked button 2!");
        targetObjectForShoot = "Target2";
        startTimer = true;
        SelectedAnswer = 2;
    }
    void TaskOnClick3()
    {
        Debug.Log("You have clicked button 3!");
        targetObjectForShoot = "Target3";
        startTimer = true;
        SelectedAnswer = 3;
    }
    void TaskOnClick4()
    {
        Debug.Log("You have clicked button 4!");
        targetObjectForShoot = "Target4";
        startTimer = true;
        SelectedAnswer = 4;
    }









    // public TMP_Text Q1Text;
    // public TMP_Text Q2Text;
    // public TMP_Text Q3Text;
    // public TMP_Text Q4Text;

    // public TMP_Text AnsText;
    private int randomNum;
    private int randomNumA;
    private int randomNumT;

    void QandAGenerate()
    {
        randomNum = Random.Range(1, 5);
        correctAnswer = randomNum;
        for (int i = 0; i < 4; i++)
        {
            if (randomNum == i+1)
            {
                //Create question and answer
                int listno = Answers.Count;
                randomNumA = Random.Range(0, listno);

                if (randomNum == 1)
                {
                    Q1Text.text = QuestionCorrect[randomNumA];
                }
                if (randomNum == 2)
                {
                    Q2Text.text = QuestionCorrect[randomNumA];
                }
                if (randomNum == 3)
                {
                    Q3Text.text = QuestionCorrect[randomNumA];
                }
                if (randomNum == 4)
                {
                    Q4Text.text = QuestionCorrect[randomNumA];
                }

                AnsText.text = Answers[randomNumA];

            }
            else
            {
                if (i+1 == 1)
                {
                    int listno = Question1.Count;
                    randomNumT = Random.Range(0, listno);
                    Q1Text.text = Question1[randomNumT];
                }
                if (i+1 == 2)
                {
                    int listno = Question2.Count;
                    randomNumT = Random.Range(0, listno);
                    Q2Text.text = Question2[randomNumT];
                }
                if (i+1 == 3)
                {
                    int listno = Question3.Count;
                    randomNumT = Random.Range(0, listno);
                    Q3Text.text = Question3[randomNumT];
                }
                if (i+1 == 4)
                {
                    int listno = Question4.Count;
                    randomNumT = Random.Range(0, listno);
                    Q4Text.text = Question4[randomNumT];
                }
            }
        }
        refreash = false;
        SelectedAnswer = 0;
        Wait = false;
    }
}


            // int listno = CorrectAns.Count;
            // randomNum = Random.Range(0, listno);