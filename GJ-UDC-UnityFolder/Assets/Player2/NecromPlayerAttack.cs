using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class NecromPlayerAttack : MonoBehaviour
{
    PlayerControls playerControls;
    bool attack;

    private void Awake()
    {
        playerControls = GetComponent<PlayerOneMovements>().playerControls;
    }

    private void OnEnable()
    {
        playerControls.Player.Enable();
    }

    private void OnDisable()
    {
        playerControls.Player.Disable();
    }

    private void Update()
    {
        attack = playerControls.Player.Attack.WasPressedThisFrame();
        if (attack)
            Attack();
    }

    private void Attack()
    {
        Debug.Log("Perform attack");
    }

    void FixedUpdate()
    {

    }
}
