using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class Necrom_Range : MonoBehaviour
{
    public event Action<Undead_State> onOutOfRange;
    [SerializeField]
    ParticleSystem VFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if ((other.transform.position - transform.position).magnitude > 5)
                onOutOfRange?.Invoke(Undead_State.UndeadUp);
        }

    }    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if ((other.transform.position - transform.position).magnitude > 5)
                onOutOfRange?.Invoke(Undead_State.UndeadDown);
        }
    }

    private void Start()
    {
        DrawCircle();
    }

    void DrawCircle(float modifier = 1)
    {
        var shape = VFX.shape;
        shape.radius = GetComponentInChildren<SphereCollider>().radius * 0.5f * modifier;
    }
}
