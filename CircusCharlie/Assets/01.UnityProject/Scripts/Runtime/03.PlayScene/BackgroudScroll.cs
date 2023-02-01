using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroudScroll : MonoBehaviour
{
    [SerializeField]
    private Transform target = default;
    [SerializeField]
    private float speed = default;

    private float range = 1280f;
    private Vector3 moveDirection = Vector3.left;

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;

        if (transform.position.x <= -range)
        {
            transform.position = target.position + Vector3.right * range;
        }
    }
}
