using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCotroller : MonoBehaviour
{
    public Rigidbody2D playerRigidbody = default;
    public float speed = default;
    public float jumpForce = default;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");

        if (xInput > 0f)
        {
            playerRigidbody.velocity = new Vector2(xInput * speed, playerRigidbody.velocity.y);
        }
        else if (xInput < 0f)
        {
            playerRigidbody.velocity = new Vector2(xInput * speed, playerRigidbody.velocity.y);
        }
        else
        {
            playerRigidbody.velocity = new Vector2(0, playerRigidbody.velocity.y);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (playerRigidbody.velocity.y == 0)
            {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpForce);
            }
        }

    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
