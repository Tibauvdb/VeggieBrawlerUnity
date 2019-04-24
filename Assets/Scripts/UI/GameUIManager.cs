using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager Instance;
    public Text TimeText;

    public Image P1CharacterSprite;
    public Image P2CharacterSprite;
    public Image[] P1Healths;
    public Image[] P2Healths;
    public RectTransform EndGameUI;

    public GameObject Player1 { get; set; }
    public GameObject Player2 { get; set; }

    private float _originalP1HealthWidth;
    private float _originalP2HealthWidth;

    private float _orP1HealthWidth;
    private float _orP2HealthWidth;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SetVariables();
        P1CharacterSprite.sprite = Player1.GetComponent<SpriteHolder>().CharacterSprite;
        P2CharacterSprite.sprite = Player2.GetComponent<SpriteHolder>().CharacterSprite;
    }

    void Update()
    {
        TimeText.text = GameControllerScript.Instance.TimeText; //Get remaining Text from GameController

        SetHealth(_orP1HealthWidth,P1Healths,Player1);
        SetHealth(_orP2HealthWidth,P2Healths,Player2);

        if(GameControllerScript.Instance.GameEnded)
            ShowEndGameUI();
    }


    private void SetHealth(float originalWidth,Image[] healths,GameObject player)
    {
            
        int maxHealth;
        int limit;
        int widthToChange;

        if (player.GetComponent<PlayerScript>().Health >= 50)
        { 
            maxHealth = 100;
            limit = 50;
            widthToChange = 0;
        }        
        else if (player.GetComponent<PlayerScript>().Health >= 20)
        { 
            maxHealth = 50;
            limit = 20;
            widthToChange = 1;
            healths[widthToChange-1].rectTransform.localScale = Vector3.Scale(Vector3.zero, healths[widthToChange - 1].rectTransform.localScale);
        }
        else
        { 
            maxHealth = 20;
            limit = 0;
            widthToChange = 2;
            healths[widthToChange - 1].rectTransform.localScale = Vector3.Scale(Vector3.zero, healths[widthToChange - 1].rectTransform.localScale);
        }

        float newWidth = (originalWidth / (maxHealth - limit) * (player.GetComponent<PlayerScript>().Health - limit));

        healths[widthToChange].rectTransform.localScale = new Vector3(newWidth, healths[widthToChange].rectTransform.localScale.y, healths[widthToChange].rectTransform.localScale.z);
              
    }

    private void SetVariables()
    {
        _orP1HealthWidth = P1Healths[0].rectTransform.localScale.x;
        _orP2HealthWidth = P2Healths[0].rectTransform.localScale.x;
        Debug.Log(_originalP1HealthWidth);
        /*foreach (Image img in P1Healths)
        {
            _orP1HealthWidth += img.rectTransform.localScale.x;
            Debug.Log(_orP1HealthWidth);
        }

        foreach (Image img in P2Healths)
        {
            _orP2HealthWidth += img.rectTransform.localScale.x;
            Debug.Log(_orP1HealthWidth);
        }*/
        Player1 = GameControllerScript.Instance.SpawnedPlayer1;
        Player2 = GameControllerScript.Instance.SpawnedPlayer2;

        //_originalEndGameUIPos = EndGameUI;
    }

    private void ShowEndGameUI()
    {
        UILerper.LerpUI(EndGameUI,new Vector2(0,EndGameUI.anchoredPosition.y),10f);
    }
}
