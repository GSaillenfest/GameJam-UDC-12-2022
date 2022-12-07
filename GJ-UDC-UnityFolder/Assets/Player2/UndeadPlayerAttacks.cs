using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


public class UndeadPlayerAttacks : MonoBehaviour
{
    PlayerControls playerControls;
    bool attack;
    int hitPoint = 1;
    Animator animator;

    private void Awake()
    {
        playerControls = GetComponent<PlayerTwoMovements>().playerControls; ;
        animator = GetComponent<Animator>();
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
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            animator.SetTrigger("Attack");
    }

    void FixedUpdate()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit enemy");
        if (other.gameObject.CompareTag("Enemy"))
            other.transform.parent.GetComponent<EnemyHealth>().TakeDamage(hitPoint);
    }
}
