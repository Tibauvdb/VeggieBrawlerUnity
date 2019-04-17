using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedTime : MonoBehaviour {

    public static int fixedFrameCount { get; private set; }
    public static float FreezelessDeltaTime { get; private set; }

    private static float _freezeTimer;
    private float _savedDelta;
    private static bool _paused;

    private void Awake()
        {
        FreezelessDeltaTime = Time.deltaTime;
        }

    private void FixedUpdate()
        {
        fixedFrameCount++;
        }

    private void Update()
        {
        if (_paused)
            {
            FreezelessDeltaTime = 0;
            return;
            }

        if (Time.timeScale == 0)
            {
            _freezeTimer -= FreezelessDeltaTime;
            if (_freezeTimer <= 0)
                {
                Time.timeScale = 1;
                }
            }
        else
            {
            FreezelessDeltaTime = Time.deltaTime;
            }
        }

    /// <summary>
    /// Freezes time for a set amount of seconds.
    /// </summary>
    /// <param name="seconds">Amount of seconds to pause the game</param>
    public static void FreezeTime(float seconds)
        {
        Time.timeScale = 0;
        _freezeTimer = seconds;
        }

    /// <summary>
    /// Pauses time completely.
    /// </summary>
    public static void TogglePause()
        {
        if (_paused)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;

        _paused = !_paused;
        }
    }
