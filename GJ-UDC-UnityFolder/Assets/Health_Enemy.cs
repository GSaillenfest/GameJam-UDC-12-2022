using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Health_Enemy : Health
{
    SoulCounter undeadPlayer;

    private IObjectPool<GameObject> enemyPool;

    protected override void Die()
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
        undeadPlayer = FindObjectOfType<SoulCounter>();
    }

}
