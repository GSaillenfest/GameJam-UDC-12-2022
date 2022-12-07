using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    int hp = 3;
    Animator animator;

    private IObjectPool<GameObject> enemyPool;

    public void TakeDamage(int hitPoint)
    {
        Debug.Log($"Hit by {hitPoint}");
        if (hp - hitPoint > 0)
        {
            hp -= hitPoint;
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Hurt"))
                animator.SetTrigger("IsHit");
        }
        else
            Die();
    }

    private void Die()
    {
        enemyPool.Release(gameObject);
    }

    public void SetPool(IObjectPool<GameObject> pool)
    {
        enemyPool = pool;
    }

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
