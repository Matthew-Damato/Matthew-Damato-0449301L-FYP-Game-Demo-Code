using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ModuleProgressionScript : MonoBehaviour
{
    public int FinalRecToLoad;
    // Create a list of all modules in the coursework
    public List<string> ModuleTitles = new List<string>();


    public static string note = "Note: A grade of C typically awards between 10-15 points.";
    public List<int> ModulePointRequirements = new List<int>();
    public int TempPointHold;
    public int PointTotal;

    public int ModuleNo = 0;

    public int minigamesPlayed = 0;
    //Start from the first module. increase to the next. This number is used to caluclate the questions and answers to be asked.

    public List<int> MinigamesPerModule = new List<int>();
    public List<int> AveGradePerModule = new List<int>();


    public GameObject Mainmanager;
    public int pointCount;

    private int temphold;

    private int C = 3;
    private int B = 2;
    private int A = 1;
    private int F = 4;


    private string TempGrade;

    public int ResultGameMode;

    public List<ListOfAchievements> Achievements = new List<ListOfAchievements>();

    public int NumberOfC;
    public int NumberOfB;
    public int NumberOfA;

    private bool GetGrade = false;

    private Scene Currentscene;

    




    public GameObject MainMenuCanvas;
    public bool algorithmcall = true;
    // Start is called before the first frame update
    void Start()
    {

        algorithmcall = true;

        Debug.Log(SceneManager.GetActiveScene());


        if (minigamesPlayed > MinigamesPerModule[ModuleNo])
        {
            ModuleNo = ModuleNo + 1;
            MinigamesPerModule[ModuleNo] = temphold;
            temphold = 0;
        }
        else
        {
            Currentscene = SceneManager.GetActiveScene();
            if ( Currentscene.name == "Minigame_1")
            {
                temphold = temphold+1;
                MainMenuCanvas.SetActive(false);
                updateOnce = true;
                minigamesPlayed += 1;
            }
        }
    }

    
    public bool NextUpdate  = true;
    public void StartFunctions()
    {
        Currentscene = SceneManager.GetActiveScene();
            if ( Currentscene.name == "Minigame_1")
            {
                if (NextUpdate == true)
                {
                    temphold = temphold+1;
                    MainMenuCanvas.SetActive(false);
                    updateOnce = true;
                    minigamesPlayed += 1;
                    NextUpdate = false;
                }

            }
            else
            {
                NextUpdate = true;
            }
    }


    public TMP_Text PointsField;



    //Call generation class:
    public Algorithm Generation_Algorithm;

    public bool updateOnce = false;
    
    public GameObject CanvasMainMenu;

    // Update is called once per frame
    private bool GradeUpdate = false;
    void Update()
    {
        StartFunctions();
        
        Debug.Log("Update");

        LevelSpawner();

        //Call the give rewards function:
        if (Currentscene.name == "Minigame_1")
        {
            Debug.Log("Scene is mini-game!");

            bool gameDone = Mainmanager.GetComponent<MainGameManager>().GameIsComplete;
            CanvasMainMenu.SetActive(false);

            if (gameDone == true)
            {

                Debug.Log("Game Complete!");

                GiveRewards();
                Like();
            }
        }



        if (Currentscene.name != "Minigame_1")
        {
            CanvasMainMenu.SetActive(true);
            Debug.Log("Listen for button click");
            Rec1Button.onClick.AddListener(Button1Clicked);
            Rec2Button.onClick.AddListener(Button2Clicked);
            
            
            
            Debug.Log("Scene is not mini-game");

            PointsField.text = PointTotal.ToString();

            
            
            if (updateOnce == true)
            {
                Debug.Log("Enter point update function: ");
                TempPointHold = Mainmanager.GetComponent<MainGameManager>().PointTotal;
                PointTotal = PointTotal + TempPointHold;
                updateOnce = false;

                Debug.Log("Points" + TempPointHold);
            }

            //Load Generation Function:
            Debug.Log("Activate Recommendation Algorithm: ");
            if (algorithmcall == true)
            {
                Recommendation_Algorithm();
                algorithmcall = false;
            }
            
        }

    }






    // List of levels
    public List<GameObject> Levels;
    private int NumberOfLevels;
    public int levelToLoad = 0;
    //LevelToLoad holds the level that must be loaded.

    // Contains a number representing the preference of that level.
    private List<int> Levelpref;

    void LevelSelect()
    {
        NumberOfLevels = Levels.Count;
        int Lpref_Length = Levelpref.Count;


        //Check that there are equal numbers of levels and level preferneces.
        if (NumberOfLevels > Lpref_Length)
        {
            //If not, introduce new level preferneces until they match.
            int number_to_add = NumberOfLevels - Lpref_Length;
            for (int i = 0; i < number_to_add; i++)
            {
                Levelpref.Add(0);
            }
        }


        Lpref_Length = Levelpref.Count;

        // Find the heigest grade level preference. 
        int HighestGrade = 0;
        int HighestGrade_value = Levelpref[0];
        for (int i = 0; i < Lpref_Length; i++)
        {
            if (Levelpref[i] > HighestGrade_value)
            {
                HighestGrade = i;
                HighestGrade_value = Levelpref[i];
            }
        }




        for (int i = 0; i < NumberOfLevels; i++)
        {
            //Loop through the Levels, and also have access to the corresponding LevelPref
            if (true)
            {
                
            }
        }
    }



    //Create a function to check the scene, and spawn the game objects needed:
    void MinigameSpawn()
    {
        if (SceneManager.GetActiveScene().name == "Minigame_1")
        {
            Instantiate(Levels[levelToLoad]);
        }
    }
    //If scene is the minigame scene, load the corresponding mini-game.











// List of minigames
//Also contains certain factors relating to the mini-games.
    public List<MinigameOptions> LevelsList;
//List of background themes - Might not be used
    public List<GameObject> Backgrounds;

//Hold the grade obtained
    string gradeObtained = "";

//Handles some data related to the algorithm, mainly allowing a public view of it's parameters
//it is also used call functions from the given class.
    public MinigameOptions Minigame_Options;


    //Function to handle tracking of grades. 
    //During the minigame scene, call this up only when one of the grades changes.
    void GradeUpdateFn()
    {
        

        //Make sure it's the manager scene.
        if (SceneManager.GetActiveScene().name == "Minigame_1")
        {
            gradeObtained = Mainmanager.GetComponent<MainGameManager>().GradeStore;
        }



        if ((string.IsNullOrEmpty(gradeObtained)))
        {
            // increase the number of total As, Bs, and Cs obtained.
            if (gradeObtained == "C")
            {
                NumberOfC += 1;
                //Use levelToLoad to access the currently loaded minigame stats
                LevelsList[levelToLoad].Number_of_C += 1;
                LevelsList[levelToLoad].highestGrade_set();
                LevelsList[levelToLoad].RecommendationLevel += 0;
            }

            if (gradeObtained == "B")
            {
                NumberOfB += 1;
                LevelsList[levelToLoad].Number_of_B += 1;
                LevelsList[levelToLoad].highestGrade_set();
                LevelsList[levelToLoad].RecommendationLevel += 1;
            }

            if (gradeObtained == "A")
            {
                NumberOfA += 1;
                LevelsList[levelToLoad].Number_of_A += 1;
                LevelsList[levelToLoad].highestGrade_set();
                LevelsList[levelToLoad].RecommendationLevel += 1.5f;
            }

            if (gradeObtained == "F")
            {
                LevelsList[levelToLoad].highestGrade_set();
                LevelsList[levelToLoad].RecommendationLevel += 0.5f;
            }


        }
        //Also need to record which mini-game is getting the highest reward.





    }


//Check if level was liked or not.
    public bool Liked = true;
    public void Like()
    {

        Liked = Mainmanager.GetComponent<MainGameManager>().liked;

        if (Liked == true)
        {
            LevelsList[levelToLoad].RecommendationLevel += 1;
        }
        else
        {
            LevelsList[levelToLoad].RecommendationLevel -= 1;
        }
    }



//Give any needed rewards
    public void GiveRewards()
    {
        //Check the grade:
        GradeUpdateFn();

    }




// Functions related to button clicks and game over updates.






// Algorithm for level selection:

    public int Number_of_minigames;

    void Set_Number_of_minigames()
    {
        Debug.Log("Inside the set number of minigames");
        Debug.Log(LevelsList.Count);
        Number_of_minigames = LevelsList.Count;
        Debug.Log("number of minigames " + Number_of_minigames);
    }
    //Above, the number of minigames was obtained.

    //Next, check which minigame has the highest grade.


    private int best_result_minigame = 0;
    private int best_result_minigame_val = 0;
    public int CurrentRecommendation;

    void Minigame_with_highest_grade()
    {
        Debug.Log("Inside the minigame with the highest grade");
        Set_Number_of_minigames();

        for (int i = 0; i < Number_of_minigames; i++)
        {
            if (LevelsList[i].Ave_mark > best_result_minigame_val)
            {
                best_result_minigame = i;
                best_result_minigame_val = LevelsList[i].Ave_mark;
            }
        }
        CurrentRecommendation = best_result_minigame;
        Debug.Log("exiting the minigame with the highest grade");
    }
    //The minigame with the highest mark has been identified. 

    // Rec1 and 2 store the 2 recommendations. 
    // Rec1 on the left.
    // Rec2 on the right.
    public int Rec1;
    private float rec1Store;
    public int Rec2;
    private float rec2Store;

    public void Recommendation_Algorithm()
    {

        Debug.Log("Inside the Recommendation Algorithm");

        //This will determain which level should be loaded next:
        //Start by obtaining the minigame with the best results:
            Minigame_with_highest_grade();
        Debug.Log("The highest grade was obtained: "+ CurrentRecommendation);
        //This is held in the current recommendation.

        //Loop through all the levels and pick the 2 with the highest recommendation level:

        Debug.Log("AAA");
        rec1Store = LevelsList[0].RecommendationLevel;
        Rec1 = Random.Range(0, LevelsList.Count-1);
        rec1Store = LevelsList[Rec1].RecommendationLevel;
        Debug.Log("Rec 1 Before alterations: "+ Rec1);

        for (int i = 0; i < Number_of_minigames; i++)
        {
            //Set Rec1 as the highest recommended level:

            if (LevelsList[i].RecommendationLevel > rec1Store)
            {
                Rec1 = i;
                rec1Store = LevelsList[i].RecommendationLevel;
            }
            
        }

        //Repeat for a second recommendation:


        rec2Store = LevelsList[0].RecommendationLevel;
        Rec2 = 0;

        if (Rec1 == 0)
        {
            Rec2 = 1;
            rec2Store = LevelsList[1].RecommendationLevel;

        }

        for (int i = 0; i < Number_of_minigames; i++)
        {
            //Set Rec2 as the highest recommended level:
            if (i != Rec1)
            {
                if (LevelsList[i].RecommendationLevel > rec1Store)
                {
                    Rec2 = i;
                    rec2Store = LevelsList[i].RecommendationLevel;
                }
            }

            
        }


        //With this, the 2 highest recommendations have been set.

        //Now update the time since last appeared:

        for (int i = 0; i < Number_of_minigames; i++)
        {
            if (i != Rec1)
            {
                if (i != Rec2)
                {
                    LevelsList[i].Time_since_last_chosen = LevelsList[i].Time_since_last_chosen + 1;
                }


                //Gives a boost to the recommendation level so that it is more likely to appear. 
                //Then resets the counter. 
                if (LevelsList[i].Time_since_last_chosen > 5)
                {
                    LevelsList[i].RecommendationLevel = LevelsList[i].RecommendationLevel + 2.5f;
                    LevelsList[i].Time_since_last_chosen = 0;
                }
            }
        }




        Debug.Log("First Recommended MiniGame "+Rec1);
        Debug.Log("Second Recommended MiniGame "+Rec2);


        //Update the buttons
        ButtonSpawner();

    }



    public Button Rec1Button;
    public Button Rec2Button;

    public Image Rec1Image;
    public Image Rec2Image;

    public List<Sprite> IconsForMiniGames;
    public List<string> MiniGamenames;

    public TMP_Text Rec1Text;
    public TMP_Text Rec2Text;

    public void ButtonSpawner()
    {
        //Spawn the two buttons and corresponding text:
        Rec1Text.text = MiniGamenames[Rec1];
        Rec2Text.text = MiniGamenames[Rec2];

        Rec1Image.sprite = IconsForMiniGames[Rec1];
        Rec2Image.sprite = IconsForMiniGames[Rec2];
        Debug.Log("ButtonSpawner");
        // Rec1Button.onClick.AddListener(Button1Clicked);
        // Rec2Button.onClick.AddListener(Button2Clicked);
    }

    public void Button1Clicked()
    {
        Debug.Log("Option 1");
        FinalRecToLoad = Rec1;
        Debug.Log(FinalRecToLoad);
         SceneManager.LoadScene("Minigame_1");
    }

    public void Button2Clicked()
    {
        Debug.Log("Option 2");
        FinalRecToLoad = Rec2;
        Debug.Log(FinalRecToLoad);
         SceneManager.LoadScene("Minigame_1");
    }
























    //Achievements: 
    public GameObject Achievement1;
    public GameObject Achievement2;
    public GameObject Achievement3;

    public void AchievementCheck()
    {
        if (PointTotal >= 60)
        {
            PointTotal = PointTotal+5;
            Achievement1.SetActive(false);   
        }
        if (gradeObtained == "A")
        {
            PointTotal = PointTotal+10;
            Achievement3.SetActive(false);   
        }
    }



















































































    bool SpawnAnObject = true;

    public void LevelSpawner()
    {
         
        //Handles the spawning of the level proper:
        if (Currentscene.name == "Minigame_1")
        {
            if (SpawnAnObject == true)
            {
                SpawnLevel();
                SpawnAnObject = false;
            }
            //Instanciate the scene:
            

        }
        else
        {
            SpawnAnObject = true;
        }
    }

    public void SpawnLevel()
    {
        Instantiate(LevelsList[FinalRecToLoad].Minigame_chosen, Vector3.zero, Quaternion.identity);
    }

















}






















//The achievements class. This will likely be moved to another script.
[System.Serializable]
public class ListOfAchievements
{
    public List<string> AchievementName;
    public List<int> AchievementRequirementNo;
    public List<string> AchievementReq;


    public void AchievementGet(int a)
    {
        //a must be equal to the number AchievementReq to present the achievement.
    }
}





































//This holds all data relating to each mini-game.

[System.Serializable]
public class MinigameOptions
{
    public GameObject Minigame_chosen;
    public int Minigame_Number;
    public string highest_Grade;
    public int Number_of_C;

    public int Number_of_B;

    public int Number_of_A;

    private int marks = 0;
    public int Ave_mark = 0;
    public float RecommendationLevel = 0;

    public int number_of_likes;
    public int Time_since_last_chosen = 0;


    public int Number_of_times_chosen = 0;
    public float DiscountFactor = 0.25f;


    //Finds the most common mark.
    public void highestGrade_set()
    {
        if (Number_of_C > Number_of_B && Number_of_C > Number_of_A)
        {
            highest_Grade = "C";
            marks = marks + 50;
        }
        if (Number_of_B > Number_of_A && Number_of_B > Number_of_C)
        {
            highest_Grade = "B";
            marks = marks + 70;
        }
        if (Number_of_A > Number_of_B && Number_of_A > Number_of_C)
        {
            highest_Grade = "A";
            marks = marks + 90; 
        }

        Ave_mark = marks/(Number_of_C+Number_of_B+Number_of_A);

        Number_of_times_chosen = Number_of_times_chosen + 1;

        // Apply the discount factor
        DecayRate();

    }

    public void DecayRate()
    {
        if (RecommendationLevel > 0)
        {
            RecommendationLevel = RecommendationLevel - DiscountFactor;
            if (RecommendationLevel > 6)
            {
                RecommendationLevel = RecommendationLevel - DiscountFactor;
            }
        }

        
    }




}








































//The algorithm class
[System.Serializable]
public class Algorithm
{
    //The Adaptive algorithm to player needs:


    public MinigameOptions Minigame_option_lists;

    //Make reference to the main class to call functions and values.
    public ModuleProgressionScript MainClass;

    public int Number_of_minigames;

    void Set_Number_of_minigames()
    {
        Debug.Log("Inside the set number of minigames");
        Debug.Log(MainClass.LevelsList.Count);
        Number_of_minigames = MainClass.LevelsList.Count;
        Debug.Log("number of minigames " + Number_of_minigames);
    }
    //Above, the number of minigames was obtained.

    //Next, check which minigame has the highest grade.


    private int best_result_minigame = 0;
    private int best_result_minigame_val = 0;
    public int CurrentRecommendation;

    void Minigame_with_highest_grade()
    {
        Debug.Log("Inside the minigame with the highest grade");
        // Set_Number_of_minigames();

        for (int i = 0; i < Number_of_minigames; i++)
        {
            if (MainClass.LevelsList[i].Ave_mark > best_result_minigame_val)
            {
                best_result_minigame = i;
                best_result_minigame_val = MainClass.LevelsList[i].Ave_mark;
            }
        }
        CurrentRecommendation = best_result_minigame;
        Debug.Log("exiting the minigame with the highest grade");
    }
    //The minigame with the highest mark has been identified. 


    public int Rec1;
    private float rec1Store;
    public int Rec2;
    private float rec2Store;

    public void Recommendation_Algorithm()
    {

        Debug.Log("Inside the Recommendation Algorithm");

        //This will determain which level should be loaded next:
        //Start by obtaining the minigame with the best results:
            Minigame_with_highest_grade();
        Debug.Log("The highest grade was obtained: "+ CurrentRecommendation);
        //This is held in the current recommendation.

        //Loop through all the levels and pick the 2 with the highest recommendation level:

        List<MinigameOptions> LevelListInstance =  MainClass.LevelsList;
        Debug.Log("AAA");
        rec1Store = LevelListInstance[0].RecommendationLevel;
        Rec1 = 0;
        Debug.Log("Rec 1 Before alterations: "+ Rec1);

        for (int i = 0; i < Number_of_minigames; i++)
        {
            //Set Rec1 as the highest recommended level:

            if (LevelListInstance[i].RecommendationLevel > rec1Store)
            {
                Rec1 = i;
                rec1Store = LevelListInstance[i].RecommendationLevel;
            }
            
        }

        //Repeat for a second recommendation:


        rec2Store = LevelListInstance[0].RecommendationLevel;
        Rec2 = 0;

        if (Rec1 == 0)
        {
            Rec2 = 1;
            rec2Store = LevelListInstance[1].RecommendationLevel;

        }

        for (int i = 0; i < Number_of_minigames; i++)
        {
            //Set Rec2 as the highest recommended level:
            if (i != Rec1)
            {
                if (LevelListInstance[i].RecommendationLevel > rec1Store)
                {
                    Rec2 = i;
                    rec2Store = LevelListInstance[i].RecommendationLevel;
                }
            }

            
        }


        //With this, the 2 highest recommendations have been set.

        //Now update the time since last appeared:

        for (int i = 0; i < Number_of_minigames; i++)
        {
            if (i != Rec1)
            {
                if (i != Rec2)
                {
                    MainClass.LevelsList[i].Time_since_last_chosen = MainClass.LevelsList[i].Time_since_last_chosen + 1;
                }


                //Gives a boost to the recommendation level so that it is more likely to appear. 
                //Then resets the counter. 
                if (MainClass.LevelsList[i].Time_since_last_chosen > 5)
                {
                    MainClass.LevelsList[i].RecommendationLevel = MainClass.LevelsList[i].RecommendationLevel + 2.5f;
                    MainClass.LevelsList[i].Time_since_last_chosen = 0;
                }
            }
        }




        Debug.Log(Rec1);
        Debug.Log(Rec2);

    }

    


}




















































public class ModuleProgress
{
    //This holds how much points are needed to get to the next module.
    public int PointsRequiredToNextModule;

    //A counter of the number of times a particular grade appears.
    private int numberOfCs;
    private int numberOfBs;
    private int numberOfAs;
    private int numberOfFs;

    //The amount increase or decrease when a number of grades are obtained in a row.
    public int APayOff = -2;
    public int CPayOff = 1;
    public int FPayOff = 2;

    //Average grade:
    public string AveGrade;
    public List<string> MostCommonGrade;

    public void FindMostCommonGrade()
    {


        //AveGrade =  MostCommonGrade.GroupBy(x => x);


    } 



}







































[System.Serializable]
public class Leaderboard
{
    //The leaderboards players will be competing against eachother in.

    public List<friends> Friends_List;
}

[System.Serializable]
public class friends
{
    //Friends to demonstrate social aspect.


}