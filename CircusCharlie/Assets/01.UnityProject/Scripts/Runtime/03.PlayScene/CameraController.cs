using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = default;
    public GameObject player = default;

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - this.transform.position;
        Vector3 move = new Vector3(direction.x * speed * Time.deltaTime, 0f, 0f);
        this.transform.Translate(move);
    }
}
