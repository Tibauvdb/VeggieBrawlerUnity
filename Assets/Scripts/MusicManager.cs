using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource _Menu;
    [SerializeField] private AudioSource _CharSel;
    [SerializeField] private AudioSource _Fight;



    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        _Menu.volume = 0;
        _CharSel.volume = 0;
        _Fight.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu" && _Menu.volume != 1)
        {
            _Menu.volume = Mathf.MoveTowards(_Menu.volume, 1, 0.15f*Time.deltaTime);
            _CharSel.volume = Mathf.MoveTowards(_CharSel.volume, 0, 0.3f*Time.deltaTime);
            _Fight.volume = Mathf.MoveTowards(_Fight.volume, 0, 0.3f*Time.deltaTime);
        }

        else if (SceneManager.GetActiveScene().name == "CharacterSelect" && _CharSel.volume !=1)
        {
            _Menu.volume = Mathf.MoveTowards(_Menu.volume, 0, 0.3f * Time.deltaTime);
            _CharSel.volume = Mathf.MoveTowards(_CharSel.volume, 1, 0.15f * Time.deltaTime);
            _Fight.volume = Mathf.MoveTowards(_Fight.volume, 0, 0.3f * Time.deltaTime);
        }

        else if (SceneManager.GetActiveScene().name == "GameScene" && _Fight.volume != 1)
        {
            _Menu.volume = Mathf.MoveTowards(_Menu.volume, 0, 0.3f *Time.deltaTime);
            _CharSel.volume = Mathf.MoveTowards(_CharSel.volume, 0, 0.3f * Time.deltaTime);
            _Fight.volume = Mathf.MoveTowards(_Fight.volume, 1, 0.15f * Time.deltaTime);
        }

        else if (SceneManager.GetActiveScene().name == "WinScreen" && _Menu.volume != 1)
        {
            _Menu.volume = Mathf.MoveTowards(_Menu.volume, 1, 0.15f * Time.deltaTime);
            _CharSel.volume = Mathf.MoveTowards(_CharSel.volume, 0, 0.3f * Time.deltaTime);
            _Fight.volume = Mathf.MoveTowards(_Fight.volume, 0, 0.3f * Time.deltaTime);
        }
    }
}
