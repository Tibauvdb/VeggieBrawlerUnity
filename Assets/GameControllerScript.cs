﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngineInternal;

public class GameControllerScript : MonoBehaviour
{
    public static GameControllerScript Instance { get; private set; }

    public bool DebugMode;
    public GameObject BasePlayerPrefab; //Used when starting in GameScene instead of coming from CharacterSelect

    public float TimeRemaining;
    public float TimeUntilGameStart;
    public float TimeToWaitAfterPlayerHasWon;
    public int Winner { get; set; }
    public string TimeText { get; set; }
    public bool GameEnded { get; set; }

    public Transform Player1SpawnPoint;
    public Transform Player2SpawnPoint;
    public Text StartGameText;
    public string ToDisplayWhenGameStarts;

    public GameObject WinningPlayer { get; set; }

    [HideInInspector] public GameObject Player1;
    [HideInInspector] public GameObject Player2;
    [HideInInspector] public GameObject SpawnedPlayer1;
    [HideInInspector] public GameObject SpawnedPlayer2;

    [SerializeField] private int _winScreenBuildIndex;

    private int player = 1;

    private bool _gameStarted;

    private Vector3 _orScale;
    // Start is called before the first frame update
    void Awake()
    {
        _orScale = StartGameText.rectTransform.localScale;

        Winner = -1;

        CreateInstance(); //create GameControllerScript Instance

        CreatePlayer(out Player1, out SpawnedPlayer1, Player1SpawnPoint); //Create Player 1
        CreatePlayer(out Player2, out SpawnedPlayer2, Player2SpawnPoint); //Create Player 2

        StartCoroutine(WaitToStartGame());
    }

    private void Update()
    {
        CheckIfTimeOver();
       //StartGameText.rectTransform.localScale =  IncreaseUISize(StartGameText.rectTransform,_orScale);
        if (_gameStarted)
        {
            CalculateRemainingTime();
            StartGameText.color = UILerper.LerpOpacity(StartGameText.color, 0, 0.05f);
        }
    }

    //Waits "TimeUntilGameStart" Seconds to start the game
    private IEnumerator WaitToStartGame()
    {
        BeforeGameStart();
        yield return new WaitForSecondsRealtime(1f);
        StartGameText.text = "3";
        yield return new WaitForSecondsRealtime(1f);
        StartGameText.text = "2";
        yield return new WaitForSecondsRealtime(1f);
        StartGameText.text = "1";
        yield return new WaitForSecondsRealtime(1f);
        StartGameText.text = "Lets Go";
        yield return new WaitForSecondsRealtime(.5f);
        StartGame();
    }

    private Vector3 IncreaseUISize(RectTransform uiScale,Vector3 orScale)
    {
        uiScale.localScale = Vector3.Lerp(uiScale.localScale, orScale + Vector3.one, Time.deltaTime * 2);
        return uiScale.localScale;
    }

    private void BeforeGameStart()
    {
        FixedTime.TogglePause();
    }

    private void StartGame()
    {
        StopAllCoroutines();

        StartGameText.text = ToDisplayWhenGameStarts;

        FixedTime.TogglePause();

        _gameStarted = true;
    }

    private void CalculateRemainingTime()
    {
        TimeRemaining -= Time.deltaTime;
        string minutes = Mathf.Floor(TimeRemaining / 60).ToString("00");
        string seconds = Mathf.Floor(TimeRemaining % 60).ToString("00");

        TimeText = minutes + ":" + seconds;
    }

    #region Everything Related To Spawning The Players

    private void CreatePlayer(out GameObject player,out GameObject spawnedPlayer,Transform spawnPoint)
    {
        player = !DebugMode ? FindObjectOfType<ChosenCharactersSaver>().ChosenCharacters[this.player-1] : BasePlayerPrefab; //get the player prefab (or spawn Base prefab when in Debug Mode)
      
        spawnedPlayer = SpawnPlayer(player, spawnPoint); //Spawn Player method

        spawnedPlayer.GetComponent<PlayerScript>().PlayerNumber = this.player;  //Set player number (1 or 2)

        CameraScript temp = GameObject.Find("Main Camera").GetComponent<CameraScript>();
        temp.ObjectsToTrack.Add(spawnedPlayer.transform); //Add player to objects that should be tracked by camera

        EnableCharacterScripts(spawnedPlayer); //Enable necessary Scripts

        this.player += 1;
    }

    private GameObject SpawnPlayer(GameObject player, Transform spawnPoint)
    {
         GameObject tempSpawn = Instantiate(player, spawnPoint);
         tempSpawn.transform.parent = null;
         return tempSpawn;
    }

    private void EnableCharacterScripts(GameObject character)
    {
        character.GetComponent<PlayerScript>().enabled = true;
        character.GetComponent<PhysicsController>().enabled = true;
    }

    #endregion

    private IEnumerator EndGameEnumerator()
    {
        //Make UI Appear?
        GameEnded = true;
        yield return new WaitForSeconds(TimeToWaitAfterPlayerHasWon);
        SceneManager.LoadScene(_winScreenBuildIndex);
        StopAllCoroutines();
    }

    private void CreateInstance()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }

    private void CheckIfTimeOver()
    {
        if (TimeRemaining <= 1)
        {
            EndGame(Player1.GetComponent<PlayerScript>().Health > Player2.GetComponent<PlayerScript>().Health ? 2 : 1);
        }
    }
    /// <summary>
    /// Call when Player has died - Other player then wins game
    /// </summary>
    /// <param name="losingPlayerNumber">This player's PlayerNumber</param>
    public void EndGame(int losingPlayerNumber)
    {
        _gameStarted = false;
        losingPlayerNumber %= 2;
        Winner = losingPlayerNumber + 1;
        StartCoroutine(EndGameEnumerator());

        WinningPlayer = Player1.ToString().Substring(player.ToString().Length - 1) == losingPlayerNumber.ToString() ? Player1 : Player2;
    }
}

    