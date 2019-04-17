using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger Instance;

    public Button StartButton;
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StartButton.Select();
    }

    /// <summary>
    /// Loads new scene
    /// </summary>
    /// <param name="scene">Scene build index</param>
    public void SceneChange(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    /// <summary>
    /// Quits The Game 
    /// </summary>
    public void QuitApplication()
    {
        Application.Quit();
    }
}
