using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBtn : MonoBehaviour
{
    public void OnPlayButton()
    {
        GFunc.LoadScene(GData.SCENE_NAME_STAGE);


    }   //  OnPlayButton()
}
