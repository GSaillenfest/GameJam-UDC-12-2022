using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Mover_Enemy : Mover
{
    Transform necromPlayer;
    Vector3 direction;

    private void OnEnable()
    {
        base.Init();
        necromPlayer = FindObjectOfType<Necrom_Range>().transform;
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

    protected override void LookRotation()
    {
        Quaternion rot;
        if ((direction).magnitude > 0.2f)
        {
            rot = Quaternion.LookRotation(direction, Vector3.up);
            rgbd.rotation = rot;
        }
    }
}
