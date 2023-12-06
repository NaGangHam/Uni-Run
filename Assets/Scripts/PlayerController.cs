using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip; // 사망시 재생할 오디오 클립
    public float jumpForce = 700f; // 점프 힘

    int jumpCount = 0; // 점프 누적
    bool isGrounded = false; // 바닥에 닿았는지 나타냄
    bool isDead = false; // 사망 상태

    Rigidbody2D playerRigidbody;
    Animator animator;
    AudioSource playerAudio;

    // Start is called before the first frame update
    void Start(){

        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update(){

        if (isDead) {  
            return;
        }

        if (Input.GetMouseButtonDown(0) && jumpCount < 2) {
            jumpCount++;
            playerRigidbody.velocity = Vector2.zero;
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            playerAudio.Play();

        }
        else if (Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0) {

            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;

        }

        animator.SetBool("Grounded", isGrounded);

    }

    void Die() {

        animator.SetTrigger("Die");
        playerAudio.clip = deathClip;
        playerAudio.Play();
        playerRigidbody.velocity = Vector2.zero;
        isDead = true;

        GameManager.Instance.OnPlayerDead();

    }

    void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "Dead" && !isDead) {
            Die();
        }


        if (other.gameObject.name == "Bronze 0") {
            GameManager.Instance.AddScore(1);
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.name == "Silver 0") {
            GameManager.Instance.AddScore(5);
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.name == "Gold 0") {
            GameManager.Instance.AddScore(10);
            other.gameObject.SetActive(false);
        }

    }

    void OnCollisionEnter2D(Collision2D collision) {

        if (collision.contacts[0].normal.y > 0.7f) {

            isGrounded = true;
            jumpCount = 0;

        }

    }

    void OnCollisionExit2D(Collision2D collision) {
        
        isGrounded = false;

    }

}
