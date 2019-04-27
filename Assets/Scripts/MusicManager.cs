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

    [SerializeField] private float _soundChangeSpeedValue;

    private bool _gameDone;


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
        
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            if (_gameDone == true)
            {
                if (_Menu.volume>=0.2f)
                {
                    _Menu.volume = Mathf.MoveTowards(_Menu.volume, 0, _soundChangeSpeedValue*2 * Time.deltaTime);
                }
                else
                {
                    Destroy(this.gameObject);
                }

            }

            else if (_Menu.volume != 1)
            {
                _Menu.volume = Mathf.MoveTowards(_Menu.volume, 1, _soundChangeSpeedValue / 2 * Time.deltaTime);
                _CharSel.volume = Mathf.MoveTowards(_CharSel.volume, 0, _soundChangeSpeedValue * Time.deltaTime);
                _Fight.volume = Mathf.MoveTowards(_Fight.volume, 0, _soundChangeSpeedValue * Time.deltaTime);
            }

        }

        else if (SceneManager.GetActiveScene().name == "CharacterSelect" && _CharSel.volume !=1)
        {
            _Menu.volume = Mathf.MoveTowards(_Menu.volume, 0, _soundChangeSpeedValue * Time.deltaTime);
            _CharSel.volume = Mathf.MoveTowards(_CharSel.volume, 1, _soundChangeSpeedValue/2 * Time.deltaTime);
            _Fight.volume = Mathf.MoveTowards(_Fight.volume, 0, _soundChangeSpeedValue * Time.deltaTime);
        }

        else if (SceneManager.GetActiveScene().name == "GameScene" && _Fight.volume != 1)
        {
            _Menu.volume = Mathf.MoveTowards(_Menu.volume, 0, _soundChangeSpeedValue *Time.deltaTime);
            _CharSel.volume = Mathf.MoveTowards(_CharSel.volume, 0, _soundChangeSpeedValue * Time.deltaTime);
            _Fight.volume = Mathf.MoveTowards(_Fight.volume, 1, _soundChangeSpeedValue/2 * Time.deltaTime);
        }

        else if (SceneManager.GetActiveScene().name == "WinScreen" && _Menu.volume != 1)
        {
            if (_gameDone == false)
            {
                _gameDone = true;
            }
            _Menu.volume = Mathf.MoveTowards(_Menu.volume, 1, _soundChangeSpeedValue/2 * Time.deltaTime);
            _CharSel.volume = Mathf.MoveTowards(_CharSel.volume, 0, _soundChangeSpeedValue * Time.deltaTime);
            _Fight.volume = Mathf.MoveTowards(_Fight.volume, 0, _soundChangeSpeedValue * Time.deltaTime);
        }
    }
}
