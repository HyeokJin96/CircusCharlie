using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;

public class TextBlink : MonoBehaviour
{
    private float time = default;

    // Update is called once per frame
    void Update()
    {
        if (time < 0.5f)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1 - time);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, time);

            if (time > 1f)
            {
                time = 0;
            }
        }

        time += Time.deltaTime;
    }
}
