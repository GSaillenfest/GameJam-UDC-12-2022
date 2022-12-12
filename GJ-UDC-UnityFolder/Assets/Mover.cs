using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public abstract class Mover : MonoBehaviour
{
    [SerializeField]
    public float speed;
    protected Rigidbody rgbd;

    private void Awake()
    {
        Init();
    }

    protected void Init()
    {
        rgbd = GetComponent<Rigidbody>();
    }

    protected virtual void LookRotation()
    {
        
    }
}
