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

    private bool isGrounded = false;
    private bool isHited = false;
    private bool isDead = false;

    private Animator playerAni = default;
    private AudioSource playerAudio = default;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAni = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == true)
        {
            return;
        }   //  if : ����� ����

        //  { �÷��̾� �̵� ���� ���� 
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

        playerAni.SetBool("Grounded", isGrounded);
        //  } �÷��̾� �̵� ���� ����
    }

    //! ���ó��
    public void Die()
    {
        playerAni.SetTrigger("Die");

        playerAudio.Play();

        playerRigidbody.velocity = Vector2.zero;
        isDead = true;
    }

    //! �浹ü ����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (0.7f < collision.contacts[0].normal.y)
        {
            isGrounded = true;
        }   //  if : 45�� ���� �ϸ��� ���� ���� ���
    }

    //! �浹ü ����
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.tag.Equals("Obstacle"))
        {
            isHited = true;
            playerAni.SetBool("Hited", isHited);

            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpForce);
        }
    }
}
