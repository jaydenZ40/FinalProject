﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI timeText;
    public float timeLeft = 240f; // 4 mins per round?
    private bool running = false;

    void Awake()
    {
        timeText = this.GetComponent<TextMeshProUGUI>();
    }

    public void StartTimer()
    {
        running = true;
    }

    public void StopTimer()
    {
        running = false;
    }

    void Update()
    {
        if (!running)
            return;
        timeLeft -= Time.deltaTime;
        int mins = (int)(timeLeft / 60f);
        int sec = (int)(timeLeft % 60);
        timeText.text = string.Format("Timer: {0:00}", mins + ":" + sec.ToString("00"));
        if (timeLeft <= 0)
        {
            print("game over");
            SceneManager.LoadScene(3);
            // something happens?
        }
    }
}