using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerCotroller : MonoBehaviour
{
    public Rigidbody2D playerRigidbody = default;

    public GameObject Life_1 = default;
    public GameObject Life_2 = default;
    public GameObject Life_3 = default;

    public float speed = default;
    public float jumpForce = default;

    private bool isGrounded = false;
    private bool isDead = false;

    private Animator playerAni = default;
    private AudioSource playerAudio = default;
    // Start is called before the first frame update
    void Start()
    {
        GData.life = 3;

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
        }   //  if : 사망시 종료

        //  { 플레이어 이동 관련 로직 

        if (GData.isGameOver == false)
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

            playerAni.SetBool("Grounded", isGrounded);

        }

        //  } 플레이어 이동 관련 로직
    }

    //! 사망처리
    public void Die()
    {
        playerAni.SetTrigger("Die");

        playerAudio.Play();

        playerRigidbody.velocity = Vector2.zero;
        isDead = true;
    }

    //! 충돌체 감지
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (0.7f < collision.contacts[0].normal.y)
        {
            isGrounded = true;
        }   //  if : 45도 보다 완만한 땅을 밟은 경우
    }

    //! 충돌체 감지
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.tag.Equals("Obstacle"))
        {
            GData.isHited = true;

            GData.life -= 1;

            switch (GData.life)
            {
                case 2:
                    Life_1.gameObject.SetActive(false);
                    break;
                case 1:
                    Life_2.gameObject.SetActive(false);
                    break;
                case 0:
                    Life_3.gameObject.SetActive(false);
                    break;
                default:
                    GData.isGameOver = true;
                    break;
            }
            playerAni.SetBool("Hited", GData.isHited);

            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpForce);
        }

        if (collision.tag.Equals("EndZone"))
        {
            GData.isGameOver = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("ScoreZone"))
        {
            GData.isPassed = true;
        }
    }
}
