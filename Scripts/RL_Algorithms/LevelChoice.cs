using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChoice : MonoBehaviour
{

    public GameObject Manager;
    public GameObject objectToSpawn;

    public int resultToSpawn;

    public List<string> ListOfMiniGameNames = new List<string>();
    public List<GameObject> ListOfMiniGameDesigns = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        resultToSpawn = Manager.GetComponent<ModuleProgressionScript>().ResultGameMode;
        Instantiate(ListOfMiniGameDesigns[resultToSpawn]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
