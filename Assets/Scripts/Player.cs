using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool isMove;
    bool isJump;
    bool isDie = false;
    bool isGoal = false;

    Rigidbody playerRb;
    

    float moveForce = 35f;
    float jumpForce = 15000f;

    int jumpCount = 0;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        PlayerMove();
        PlayerJump();
    }


    void GetInput()
    {
        isMove = Input.GetButton("Horizontal");
        isJump = Input.GetButtonDown("Jump");
    }


    void PlayerMove()
    {
        if(isMove)
        {
            float Horizontal = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * Horizontal * moveForce*Time.deltaTime);
            
        }
    }

    void PlayerJump()
    {
        if (isJump && jumpCount < 2)
        {
            jumpCount++;

            playerRb.velocity = Vector3.zero;
            playerRb.AddForce(new Vector3(0,jumpForce,0));


        }
        else if (!isJump && playerRb.velocity.y>0)
        {
            playerRb.velocity = playerRb.velocity * 0.5f;
        }
    }

    public void JumpUp()
    {
            jumpCount = 0;
    }

    void Die()
    {
        isDie = true;
        
        gameObject.SetActive(false);

        GameManager.instance.Dead();
    }

    void Finish()
    {
        GameManager.instance.Win();
    }

    private void OnCollisionEnter(Collision collision)
    {
        jumpCount = 0;

        if(collision.gameObject.tag == "Finish")
        {
            Finish();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "DeadZone" && !isDie)
        {
            Die();
        }
    }
}
