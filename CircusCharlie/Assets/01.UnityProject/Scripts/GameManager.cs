using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText = default;
    public TMP_Text bonusText = default;

    public bool isGameOver = false;

    public float score = default;
    public float bonus = default;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        bonus = 5000;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {

            score += Time.deltaTime;
            bonus -= Time.deltaTime * 10;

            scoreText.text = "1P - " + 100 * (int) score;
            bonusText.text = "BONUS - " + (int) bonus;
        }


    }
}
