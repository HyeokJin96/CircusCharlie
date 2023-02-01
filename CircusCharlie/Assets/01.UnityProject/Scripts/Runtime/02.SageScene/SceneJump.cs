using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneJump : MonoBehaviour
{
    public float time = default;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("GFunc.LoadScene(GData.SCENE_NAME_PLAY)", time);
    }
}
