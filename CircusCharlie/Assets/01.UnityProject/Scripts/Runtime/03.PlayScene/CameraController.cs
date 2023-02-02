using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target = default;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, 0f, transform.position.z);
    }
}
