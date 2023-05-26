using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PossibleAndScript : MonoBehaviour
{
    // Start is called before the first frame update

    //check starting tag
    //Generate a random number

    public bool isCorrect = false;

    public List<string> CorrectAns = new List<string>(new string[] { "SARSA", "Q-Learning", "Reward based learning" });
    public List<string> IncorrectAns = new List<string>(new string[] { "Bongo Sort", "Linked lists", "Bubble Sort" });

    public TMP_Text displayText;

    private int randomNum = 0;

    void Start()
    {
        if (gameObject.tag == "Answer")
        {
            isCorrect = true;
            int listno = CorrectAns.Count;
            randomNum = Random.Range(0, listno);
        }
        else
        {
            if(isCorrect == false)
            {
                int listno = IncorrectAns.Count;
                randomNum = Random.Range(0, listno);
            }
        }

        




    }

    // Update is called once per frame
    void Update()
    {
        if(isCorrect == true)
        {
            displayText.text = CorrectAns[randomNum];
        }

        if(isCorrect == false)
        {
            displayText.text = IncorrectAns[randomNum];
        }
        
    }
}
