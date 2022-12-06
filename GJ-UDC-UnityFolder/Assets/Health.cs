using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    int hp = 3;

    public void TakeDamage(int hitPoint)
    {
        Debug.Log($"Hit by {hitPoint}");
        if (hp - hitPoint > 0)
            hp -= hitPoint;
        else
            Die();
    }

    private void Die()
    {
        transform.parent.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
