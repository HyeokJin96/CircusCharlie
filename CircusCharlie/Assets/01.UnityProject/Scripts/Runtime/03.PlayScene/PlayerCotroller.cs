using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
        float xspeed = xInput * speed;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerRigidbody.AddForce(new Vector2(speed, 0f));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerRigidbody.AddForce(new Vector2(-speed, 0f));
        }
        if (Input.GetKey(KeyCode.Space))
        {
            playerRigidbody.velocity = Vector2.zero;

            playerRigidbody.AddForce(new Vector2(0f, jumpForce));
        }
        else if (Input.GetKey(KeyCode.Space) && 0 < playerRigidbody.velocity.y)
        {
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }

        Vector2 newVelocity = new Vector2(xspeed, 0f);
        playerRigidbody.velocity = newVelocity;
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
