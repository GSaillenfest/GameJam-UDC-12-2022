using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


public class Attack_UndeadPlayer : MonoBehaviour, IHitboxResponder
{
    [SerializeField]
    HitBox hitbox;
    PlayerControls playerControls;
    bool attack;
    int damage = 1;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerControls = GetComponent<PlayerTwoMovements>().playerControls;
    }


    private void Update()
    {
        attack = GetComponent<PlayerTwoMovements>().playerControls.Player1.Attack.WasPressedThisFrame();
        if (attack)
            Attack();
    }

    private void Attack()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            animator.SetTrigger("Attack");
            hitbox.useResponder(this);
        }
    }

    public void StartAttack()
    {
        hitbox.EnableCheckCollision();
    }

    public void StopAttack()
    {
        hitbox.DisableCheckCollision();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("Enemy"))
        //{
        //    if (collision.collider.name == "BumpBox")
        //    {
        //        GetComponent<UndeadStateManager>().SwitchState(Undead_State.UndeadHurt);
        //        animator.SetTrigger("IsHit");
        //    }
        //    else if (collision.collider.name == "HitBox")
        //    {
        //        collision.transform.GetComponent<EnemyHealth>().TakeDamage(hitPoint);
        //    }
        //}
    }

    public void CollisionedWith(Collider collider)
    {
        Hurtbox hurtbox = collider.GetComponent<Hurtbox>();
        hurtbox?.TakeDamage(damage);
        Debug.Log("hit enemy");
    }
}
