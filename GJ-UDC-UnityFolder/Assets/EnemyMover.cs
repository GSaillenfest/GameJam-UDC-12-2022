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
    Vector3 direction;

    private void OnEnable()
    {
        necromPlayer = FindObjectOfType<Necrom_Range>().transform;
        rgbd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = (necromPlayer.position - transform.position);
        LookRotation();
    }

    private void FixedUpdate()
    {
        rgbd.velocity = speed * direction.normalized;
    }

    private void LookRotation()
    {
        Quaternion rot;
        if ((direction).magnitude > 0.2f)
        {
            rot = Quaternion.LookRotation(direction, Vector3.up);
            rgbd.rotation = rot;
        }
    }
}
