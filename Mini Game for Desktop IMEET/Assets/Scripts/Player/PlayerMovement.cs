using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script untuk menjalankan player
public class PlayerMovement : MonoBehaviour
{
    // player speed
    private float _speed;

    private Rigidbody _playerRb;

    // Variable container for input axis
    private float _horizontalMove;
    private float _verticalMove;

    // player movement based on vector 3
    private Vector3 _movementOfPlayer;
    private Vector3 _jumpMovementOfPlayer;

    // checking if player is moving
    private bool isPlayerMove;
    
    // checking if player is jumping
    private bool isPlayerJump;

    // check if player is on the ground
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _speed = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
    }

    void FixedUpdate()
    {
        PlayerMove();
        PlayerJump();
    }

    // Membaca input dari user
    private void ReadInput()
    {
        ReadPlayerMove();
        ReadPlayerJump();
    }

    // Membaca input player bergerak
    private void ReadPlayerMove()
    {
        _horizontalMove = Input.GetAxis("Horizontal");

        _movementOfPlayer = new Vector3(0.0f, 0.0f, _horizontalMove * -1f);

        isPlayerMove = true;
    }

    private void ReadPlayerJump()
    {
        float jumpForce = 10f;

        _jumpMovementOfPlayer = new Vector3(0f, jumpForce, 0f);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            isPlayerJump = true;
        }
        /*if (Input.GetKeyDown(KeyCode.Space) && IsGrounded == true)
        {
            isPlayerJump = true;
            IsGrounded = false;
        }*/
    }

    // Gerakan player maju, mundur, kesamping
    private void PlayerMove()
    {
        if (isPlayerMove)
        {
            _playerRb.AddForce(_movementOfPlayer * _speed);
        }
    }

    private void PlayerJump()
    {
        if (isPlayerJump)
        {
            _playerRb.AddForce(_jumpMovementOfPlayer, ForceMode.Impulse);
            isPlayerJump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            isPlayerJump = false;
        }
    }
}