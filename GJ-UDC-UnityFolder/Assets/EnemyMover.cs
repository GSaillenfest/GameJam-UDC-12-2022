using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class EnemyMover : MonoBehaviour
{
    [SerializeField]
    float speed = 1f;
    Transform necromPlayer;
    Rigidbody rgbd;

    private void OnEnable()
    {
        necromPlayer = FindObjectOfType<Necrom_Range>().transform;
        rgbd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rgbd.velocity = (necromPlayer.position - transform.position).normalized * speed;
    }
}
