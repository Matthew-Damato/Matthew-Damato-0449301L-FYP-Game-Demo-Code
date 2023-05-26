using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainGameManager : MonoBehaviour
{
    private Scene Currentscene;
    public GameObject Endscreen;
    public bool GameIsComplete = false;

    public string scenename = "Menu2";

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public GameObject CurrentGameManager;
    bool minigameCheck;
    // Start is called before the first frame update
    string scriptName;

    private Component targetScript;
    void Start()
    {
        minigameCheck = GameObject.FindGameObjectWithTag("GameController");
        //Check if this is a mini game or not.
        if (minigameCheck == true)
        {
            CurrentGameManager = GameObject.FindWithTag("GameController");
            MonoBehaviour NeededScript = CurrentGameManager.GetComponent<MonoBehaviour>();
            scriptName = NeededScript.GetType().Name;
            
            GameIsComplete = false;
            targetScript = CurrentGameManager.GetComponent(scriptName);
        }
        GameChecker = true;

    }

    void StartFn()
    {
        minigameCheck = GameObject.FindGameObjectWithTag("GameController");
        //Check if this is a mini game or not.
        if (minigameCheck == true)
        {
            CurrentGameManager = GameObject.FindWithTag("GameController");
            MonoBehaviour NeededScript = CurrentGameManager.GetComponent<MonoBehaviour>();
            scriptName = NeededScript.GetType().Name;
            
            GameIsComplete = false;
            targetScript = CurrentGameManager.GetComponent(scriptName);
        }
        GameChecker = true;
    }


    public int PointTotal;

    private bool UpdatePointCheck = false;

    public bool GameChecker = true;

    public bool RunOnce = true;
    
    // Update is called once per frame
    void Update()
    {

        
        if (Currentscene.name != "Minigame_1")
        {
            RunOnce = true;
        }

        Currentscene = SceneManager.GetActiveScene();


        Debug.Log("MainGameManagerFN");

        if (Currentscene.name == "Minigame_1")
        {
            if (RunOnce == true)
            {
                StartFn();
                RunOnce = false;
            }
        

        minigameCheck = GameObject.FindGameObjectWithTag("GameController");
        //Check if this is a mini game or not.
        if (minigameCheck == true)
        {
            
            if (GameChecker == true)
            {
                CurrentGameManager = GameObject.FindWithTag("GameController");
                MonoBehaviour NeededScript = CurrentGameManager.GetComponent<MonoBehaviour>();
                scriptName = NeededScript.GetType().Name;
            
                GameIsComplete = false;
                targetScript = CurrentGameManager.GetComponent(scriptName);

                GameChecker = false;
            }
            
        }













        Debug.Log(scriptName);


        if (minigameCheck == true)
        {
            
            
            Debug.Log("The name of the script attached to " + CurrentGameManager.name + " is " + scriptName);
            
            // int tempHold = CurrentGameManager.GetComponent<targetScript>().points_earned;
            var tempHold_Var = targetScript.GetType().GetField("points_earned").GetValue(targetScript);
            int tempHold = (int)tempHold_Var;

            // GameIsComplete = CurrentGameManager.GetComponent<GameManager1>().GameComplete;
            var GameIsComplete_Var = targetScript.GetType().GetField("GameComplete").GetValue(targetScript);
            GameIsComplete = (bool)GameIsComplete_Var;

            Debug.Log(GameIsComplete);

            if (GameIsComplete == true)
            {
                //Increase player point total:
                if (UpdatePointCheck == false)
                {
                    scenename = "Menu2";
                    PointTotal = PointTotal + tempHold;
                    UpdatePointCheck = true;
                }
                

                //Display end screen:
                //Load Scene
                EndScreenDisplay();

            }
            else
            {
                Endscreen.SetActive(false);
            }
        }
        }

        else
        {
            Endscreen.SetActive(false);
        }

    }












    public TMP_Text EndScore; 
    public bool PassOrFail;
    public Button HomeButton;
    public string GradeStore;

    public Button Like;
    public Button dislike;
    public bool liked = true;

    private void EndScreenDisplay()
    {
        if(GameIsComplete == true)
        {
            Endscreen.SetActive(true);
            //Code for creating the end screen:

            //Start by checking if it's a pass or fail:
            // PassOrFail = CurrentGameManager.GetComponent<GameManager1>().PassOrFail;
            var PassOrFail_var = targetScript.GetType().GetField("PassOrFail").GetValue(targetScript);
            PassOrFail = (bool)PassOrFail_var;
            
            if (PassOrFail == true)
            {
                //Display Grade
                // EndScore.text = CurrentGameManager.GetComponent<GameManager1>().Grade;
                var EndScore_var = targetScript.GetType().GetField("Grade").GetValue(targetScript);
                GradeStore = (string)EndScore_var;
                EndScore.text = (string)EndScore_var;
            }
            else 
            {
                GradeStore = "F";
                EndScore.text = "F";
                EndScore.color = Color.red;
            }

        }
        else
        {
            Endscreen.SetActive(false);
        }

        //Button Click for home menu:
        Button btn = HomeButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);

        Button btnLike = Like.GetComponent<Button>();
		btnLike.onClick.AddListener(approve);

        Button btndislike = dislike.GetComponent<Button>();
		btndislike.onClick.AddListener(disapprove);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene(scenename);
    }

    void approve()
    {
        liked = true;
    }

    void disapprove()
    {
        liked = false;
    }


}
