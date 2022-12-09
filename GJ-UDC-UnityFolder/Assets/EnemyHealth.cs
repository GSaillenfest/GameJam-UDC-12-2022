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
    SoulCounter undeadPlayer;

    private IObjectPool<GameObject> enemyPool;

    private void OnEnable()
    {
        hp = 3;
    }

    public void TakeDamage(int damage)
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

    private void Die()
    {
        enemyPool.Release(gameObject);
        undeadPlayer.AddToSoulCount();
    }

    public void SetPool(IObjectPool<GameObject> pool)
    {
        enemyPool = pool;
    }

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        undeadPlayer = FindObjectOfType<SoulCounter>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
