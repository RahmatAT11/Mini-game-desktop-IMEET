using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    // Player Attacking Power
    public int AttackPower { get; set; }

    private Rigidbody playerRb;

    // checking if player doing an dash attack
    private bool isPlayerDashAttack;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        AttackPower = 5;
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
    }

    private void FixedUpdate()
    {
        PlayerDashAttack();
    }

    private void ReadInput()
    {
        ReadPlayerDashAttack();
    }

    private void ReadPlayerDashAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isPlayerDashAttack = true;
        }
    }

    void PlayerDashAttack()
    {
        float dashSpeedSlower = 20f;

        if (isPlayerDashAttack)
        {
            playerRb.AddForce(Vector3.forward * dashSpeedSlower, ForceMode.Impulse);
            isPlayerDashAttack = false;
        }
    }
}
