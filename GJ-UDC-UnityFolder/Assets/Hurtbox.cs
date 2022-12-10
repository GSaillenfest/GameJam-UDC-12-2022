using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    [SerializeField]
    Health health;

    public void TakeDamage(int damage)
    {
        health.TakeDamage(damage);
    }


}
