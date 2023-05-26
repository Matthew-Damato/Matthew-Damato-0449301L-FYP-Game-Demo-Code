using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerProfile : MonoBehaviour
{
    //Used to record player progress
    public int levels_complete = 0;
    //Used to get the base player preference for the first level run
    public int basePreference;
    //This will be checked by another script.
    public bool FirstTime = true;
    //point store
    public float pointStore;

    // Create an array to hold the list of possible themes:
    int[] ThemeList = {1,2,3};
    string[] Themes = {"Fantasy", "Si-fi", "Realistic"};

    //Arrays to hold list of mini games
    int[] MinigameList = {1,2,3};
    string[] Minigames = {"collect", "maze", "platform"}; 

    //Gameobject for first time log-in
    public GameObject firstTimeScreen;
    public GameObject TextFieldForName;
    public string UserName;
    public InputField UserNameEnter;
    public string BaseThemePref;
    public InputField BaseThemePrefEnter;
    // public string DifficultyPref;
    // public InputField DifficultyPrefEnter;

    public Button CloseFirstMenu;
    // public Button NextLevel;


    public string HomeScene;



    //Continuity and in-between for level progression:
    

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        if (FirstTime == false)
        {
            firstTimeScreen.SetActive(false);
        }
    }




    // Update is called once per frame
    void Update()
    {
        if (FirstTime == true)
        {
            FirstTimeScreen();
        }
        else
        {
            firstTimeScreen.SetActive(false);
        }

        // Next, manage the event board:

        //Identify if the player has clicked the next level button.
        // NextLevel.onClick.AddListener(LoadNextLvL);


    }







    private bool ButtonClicked = false;
    void FirstTimeScreen()
    {
        
        UserName = UserNameEnter.text;
        BaseThemePref = BaseThemePrefEnter.text;


        Text text = TextFieldForName.GetComponent<Text>();
        text.text = UserName;

        CloseFirstMenu.onClick.AddListener(CloseFirstTimeScreen);

        if(ButtonClicked == true)
        {
            if (!string.IsNullOrEmpty(UserName))
            {
                if (BaseThemePref == "fantasy" || BaseThemePref == "Fantasy")
                {
                    basePreference = 1;
                }
                if (BaseThemePref == "Si-fi" || BaseThemePref == "si-fi")
                {
                    basePreference = 2;
                }
                if (BaseThemePref == "realistic" || BaseThemePref == "realistic")
                {
                    basePreference = 3;
                }


                FirstTime = false;
            }
            else
            {
                Debug.Log ("Username empty");
                Debug.Log (UserName);
            }
            
        }

        ButtonClicked = false;
        


    }





















    void CloseFirstTimeScreen()
    {
        Debug.Log ("You have clicked the button!");
        ButtonClicked = true;
    }

    // Return back to the main menu
    void LevelComplete()
    {
        levels_complete = levels_complete + 1;
        SceneManager.LoadScene(HomeScene);
    }

    //Call and load the next level scene.
    // public void LoadNextLvL()
    // {
    //     SceneManager.LoadScene(levels_complete);
    // }



}
