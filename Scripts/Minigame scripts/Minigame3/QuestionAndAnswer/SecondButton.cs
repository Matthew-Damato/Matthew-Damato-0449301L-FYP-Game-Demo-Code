using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondButton : MonoBehaviour
{

    public Button nextQuestionButton;
    public bool valHold = false;
    public GameObject Gamemanerer;
    public bool acceptinput = true;
    public int counter;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // acceptinput = true;
        if (acceptinput == true)
        {
            nextQuestionButton.onClick.AddListener(NextQuestionClicked);
        }
        // if (acceptinput == false)
        // {
            // valHold = Gamemanerer.GetComponent<GameControllerScript>().temp;
            // valHold = false;
        // }



        if (valHold == true)
        {
            counter = counter+1;
            valHold = false;
        }

        acceptinput = true;
        
    }

    private void NextQuestionClicked()
    {
        if (acceptinput == true)
        {
            Debug.Log("Button pressed!");
            valHold = true;
            acceptinput = false;
        }
        
        
    }
}
