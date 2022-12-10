using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Health : MonoBehaviour
{
    [SerializeField]
    int maxHP;
    [SerializeField]
    Animator animator;

    int hp;

    public virtual void Init()
    {
        hp = maxHP;
    }

    public virtual void TakeDamage(int damage)
    {
        Debug.Log($"Hit by {damage}");
        if (hp - damage > 0)
        {
            hp -= damage;
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Hurt"))
                animator.SetTrigger("IsHit");
        }
        else
            Die();
    }

    public virtual void Die()
    {
    
    }

    private void OnEnable()
    {
        Init();
    }

}
