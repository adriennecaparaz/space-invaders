﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public TextMeshProUGUI text;

    void Awake(){
        text = gameObject.GetComponent<TextMeshProUGUI>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "score: " + score;
    }
}
