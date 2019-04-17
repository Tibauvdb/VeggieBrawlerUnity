using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinnerTextScript : MonoBehaviour
{
    [SerializeField] private int _characterSelectBuildIndex;

    private void Start()
        {
        GetComponent<Text>().text = "PLAYER " + GameControllerScript.Instance.Winner;
        }

    private void Update()
        {
        if (Input.GetButtonDown("Submit"))
            {
            SceneManager.LoadScene(_characterSelectBuildIndex);
            }
        }
    }
