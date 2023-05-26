using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScoreA : MonoBehaviour
{
    public int TimeForMark1;
    public int TimeForMark2;
    public int TimeForMark3;

    public int MistakeCounterForMark1;
    public int MistakeCounterForMark2;
    public int MistakeCounterForMark3;

    public float timer = 0;
    public int MistakeCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if ( timer < TimeForMark1)
        {
            Debug.Log("A");
        }
        if ( timer < TimeForMark2 && timer > TimeForMark1)
        {
            Debug.Log("B");
        }
        if ( timer < TimeForMark3 && timer > TimeForMark2 && timer > TimeForMark1)
        {
            Debug.Log("C");
        }
        if (timer >= TimeForMark3)
        {
            Debug.Log("D");
        }

        if (MistakeCount > MistakeCounterForMark3)
        {
            //Print Game Over. You lose.
            Debug.Log("H");
        }

        if (MistakeCount > MistakeCounterForMark1)
        {
            Debug.Log("E");
        }
        if (MistakeCount == MistakeCounterForMark2)
        {
            //Print Game Over. You lose.
            Debug.Log("F");
        }
        if (MistakeCount == MistakeCounterForMark3)
        {
            //Print Game Over. You lose.
            Debug.Log("G");
        }
    }
}
