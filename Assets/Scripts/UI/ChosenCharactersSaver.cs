using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChosenCharactersSaver : MonoBehaviour
{
    public static ChosenCharactersSaver Instance;
    public GameObject[] ChosenCharacters = new GameObject[2];
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);   
    }
}
