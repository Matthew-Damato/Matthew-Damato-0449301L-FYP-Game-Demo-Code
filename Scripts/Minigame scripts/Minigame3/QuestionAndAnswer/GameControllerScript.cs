using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class GameControllerScript : MonoBehaviour
{

    public bool GameComplete = false;
    public bool PassOrFail = true;
    public string Grade;
    public int points_earned = 0;

    public List<string> QuestionsList = new List<string>();
    public List<AnswerClass> AnswerListClass;
    


    public TMP_InputField answer;
    public TMP_Text QuestionField;
    public TMP_Text PointsField;
    public TMP_Text TimeField;

    public Button sumbitButton;
    public Button nextQuestionButton;
    public Button Fake; //I need this button otherwise it crashes? WHY?!
    public GameObject ThisGameObject;


    public float timer;

    public int currentQuestion = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public string answerSubmission;

    public bool temp;

    // Update is called once per frame
    void Update()
    {

        TimerClass();
        // temp = ThisGameObject.GetComponent<SecondButton>().valHold;
        // if (temp == true)
        // {
        //     currentQuestion = currentQuestion+1;
        //     temp = false;
        // }
        currentQuestion = ThisGameObject.GetComponent<SecondButton>().counter;
        

        PointsField.text = points_earned.ToString();
        int timerdisplay = Mathf.RoundToInt(timer);
        TimeField.text = timerdisplay.ToString();

        while (currentQuestion < QuestionsList.Count)
        {
            timer += Time.deltaTime;
            answerSubmission = answer.text;

            QuestionField.text = QuestionsList[currentQuestion];



            sumbitButton.onClick.AddListener(SubmitClicked);
            nextQuestionButton.onClick.AddListener(NextQuestionClicked);

        }

        if (currentQuestion >= QuestionsList.Count)
        {
            GameComplete = true;

            if (points_earned >= 30)
            {
                Grade = "A";
                points_earned = 30;
            }
            if (points_earned < 30 && points_earned >= 20)
            {
                Grade = "B";
                points_earned = 20;
            }
            if (points_earned < 20 && points_earned >= 15)
            {
                Grade = "C";
                points_earned = 10;
            }
            if (points_earned < 15)
            {
                points_earned = 0;
                PassOrFail = false;
                Grade = "F";
            }

        }        

    }

    private void NextQuestionClicked()
    {
        currentQuestion = currentQuestion+1;
    }


    public bool isCorrect = false;
    private void SubmitClicked()
    {
        
        int Cntr = 0;

        for (int i = 0; i < AnswerListClass[currentQuestion].AnswerList.Count; i++)
        {
            Debug.Log("Starting Loop");
            if (answerSubmission == AnswerListClass[currentQuestion].AnswerList[i])
            {
                points_earned = points_earned+1;
                isCorrect = true;
                ShotsAndBarFilled();
                AnswerListClass[currentQuestion].AnswerList.Remove(answerSubmission);
                
                answerSubmission = " ";
                timer = timer - 5;
                i = 100;
                Debug.Log("i =  " + i);
                break;
            }

            else
            {
                Cntr += 1;
                isCorrect = false;
                Debug.Log("Please Work");
            }
        }



        
        Debug.Log("Counter: " + Cntr);
        Debug.Log("Number To Beat " + AnswerListClass[currentQuestion].AnswerList.Count);
        if (isCorrect == false)
        {
            if (Cntr > AnswerListClass[currentQuestion].AnswerList.Count)
            {
                Debug.Log("FALSE! INCORRECT ANSWER!");
                Cntr = 0;
                ShotsAndBarFilledPlayer();
                // Activate player gets shot code:
                Cntr = 0;
            }
            Cntr = 0;
            currentQuestion = currentQuestion+1;
            // points_earned = points_earned-1;
        }
        answerSubmission = " ";
    }

    

    public void TimerClass()
    {
        if (timer > 15)
        {
            currentQuestion = currentQuestion+1;
            timer = 0;
            points_earned = points_earned - 1;
        }
    }



    public List<GameObject> BartoFill;
    public GameObject PlayerObject;
    public GameObject Projectile;
    public GameObject EnemyObject;
    public Transform launchPoint;

    public float launchForce = 100f;


    public void ShotsAndBarFilled()
    {
        LaunchProjectile();
    }

    void LaunchProjectile()
    {
        // Instantiate the projectile prefab at the launch point
        GameObject projectileInstance = Instantiate(Projectile, launchPoint.position, launchPoint.rotation);

        // Get the rigidbody component of the projectile
        // Rigidbody projectileRigidbody = projectileInstance.GetComponent<Rigidbody>();

        // // Add force to the rigidbody to launch the projectile forward
        // projectileRigidbody.AddForce(launchPoint.forward * launchForce, ForceMode.Impulse);
    }












    public GameObject ProjectileE;
    public Transform launchPointEnemy;

    public void ShotsAndBarFilledPlayer()
    {
        LaunchProjectilePlayer();
    }

    void LaunchProjectilePlayer()
    {
        // Instantiate the projectile prefab at the launch point
        GameObject projectileInstance = Instantiate(ProjectileE, launchPointEnemy.position, launchPointEnemy.rotation);

    //     // Get the rigidbody component of the projectile
    //     Rigidbody projectileRigidbody = projectileInstance.GetComponent<Rigidbody>();

    //     // Add force to the rigidbody to launch the projectile forward
    //     projectileRigidbody.AddForce(launchPointEnemy.forward * launchForce, ForceMode.Impulse);
    }


    
}













[System.Serializable]
public class AnswerClass
{
    public List<string> AnswerList = new List<string>();
}
