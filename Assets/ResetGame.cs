using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour
{
    void Start()
    {
        if (GameObject.Find("GameController"))
            Destroy(GameObject.Find("GameController"));

        if(GameObject.Find("SaveChosenCharacters"))
            Destroy(GameObject.Find("SaveChosenCharacters"));
    }
}
