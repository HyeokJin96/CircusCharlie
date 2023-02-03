using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMP_Text playerText = default;
    public TMP_Text scoreText = default;
    public TMP_Text bonusText = default;

    public float score = default;
    public float bonus = default;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowText());

        GData.life = 3;
        score = 0;
        bonus = 5000;
        GData.isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GData.isGameOver)
        {
            Invoke("SetInfoScore", 1f);

            scoreText.text = " " + score.ToString("000000");
            bonusText.text = "BONUS - " + bonus.ToString("0000");

            if (GData.isPassed == true)
            {
                score += 200;
                GData.isPassed = false;
            }
        }
    }

    public void SetInfoScore()
    {
        CancelInvoke();

        bonus -= 10f;
        score += 100f;
    }

    IEnumerator ShowText()
    {
        while (!GData.isGameOver)
        {
            playerText.color = Color.black;
            yield return new WaitForSeconds(0.5f);
            playerText.color = Color.white;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
