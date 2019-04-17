using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectManager : MonoBehaviour
{
    public static CharacterSelectManager Instance;

    public float MouseMoveSpeed;
    public float CharacterSelectBorderMoveSpeed;
    public float StartGameMoveSpeed;

    public RectTransform StartGameUI;
    public PlayerUI[] AreCharactersChosen = new PlayerUI[2];

    private Vector2 _originalUIPos;
    private bool _allowStartGame;
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        AreCharactersChosen = FindObjectsOfType<PlayerUI>();
        _originalUIPos = StartGameUI.anchoredPosition; //Save original UI Pos to Unlerp it if Necessary
    }

    void Update()
    {
        if (!AreCharactersChosen[0].AllowMouseMovement && !AreCharactersChosen[1].AllowMouseMovement) //If both players have chosen a character
        {
            ShowStartGameUI();
            _allowStartGame = true;
        }
        else
        {
            HideStartGameUI();
            _allowStartGame = false;
        }

        if(_allowStartGame && Input.GetButtonDown("StartButton"))
            StartGame();
    }

    private void StartGame()
    {
        //Save Chosen Characters And Go To Game Scene 
        for (int i = 0; i < AreCharactersChosen.Length; i++)
        {
            ChosenCharactersSaver.Instance.ChosenCharacters[i] = AreCharactersChosen[i].ChosenCharacter;
        }

        SceneManager.LoadScene(2);
    }

    private void ShowStartGameUI()
    {
       UILerper.LerpUI(StartGameUI,new Vector2(0,_originalUIPos.y),StartGameMoveSpeed);
    }

    private void HideStartGameUI()
    {
        UILerper.LerpUI(StartGameUI,_originalUIPos,StartGameMoveSpeed);
    }
}
