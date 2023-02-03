using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SceneJump : MonoBehaviour
{
    public TMP_Text stageText = default;
    public TMP_Text playerText = default;

    public float time = default;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(JumpScene());
        StartCoroutine(TextBlink());
    }

    IEnumerator JumpScene()
    {
        yield return new WaitForSeconds(time);

        GFunc.LoadScene(GData.SCENE_NAME_PLAY);
    }

    IEnumerator TextBlink()
    {
        while (true)
        {
            stageText.color = Color.black;
            playerText.color = Color.black;
            yield return new WaitForSeconds(0.5f);
            stageText.color = Color.white;
            playerText.color = Color.white;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
