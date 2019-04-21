using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameEndManager : MonoBehaviour
{
    public bool Debug;
    public Text WinnerText;
    private GameObject _winningPlayer;

    void Start()
    {
        if (!Debug)
        {
            //Get winning player
            _winningPlayer = Instantiate(GameControllerScript.Instance.WinningPlayer, this.gameObject.transform);
            //Disable movement scripts
            _winningPlayer.GetComponent<PlayerScript>().enabled = false;
            _winningPlayer.GetComponent<PhysicsController>().enabled = false;

            WinnerText.text = _winningPlayer.GetComponent<PlayerScript>().CharacterName;
        }
    }

    void Update()
    {
        //RotateMe();

        if (Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene(0);
        }
    }
    private void RotateMe()
    {
        this.gameObject.transform.Rotate(Vector3.up,1);
    }
}
