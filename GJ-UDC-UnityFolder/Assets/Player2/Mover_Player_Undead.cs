using System;
using UnityEngine;
using UnityEngine.InputSystem;

    [RequireComponent(typeof(Rigidbody))]
public class Mover_Player_Undead : Mover
{
    public PlayerControls playerControls;
    Vector2 move;
    Vector3 movement;
    //Animator animator;

    private void Awake()
    {
        base.Init();
        //animator = GetComponent<Animator>();
        playerControls = new();
        FindObjectOfType<Necrom_Range>().onOutOfRange += ChangeState;
    }

    private void OnEnable()
    {
        EnableControls();
    }


    private void OnDisable()
    {
        DisableControls();
    }

    private void Update()
    {
        move = playerControls.Player1.Move.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        Move();
        LookRotation();
    }

    private void Move()
    {
        movement = (move.x * Camera.main.transform.right + move.y * Camera.main.transform.forward);
        movement.y = 0;
        movement = GetComponent<UndeadStateManager>().State.Speed * movement.normalized;
        rgbd.velocity = movement;
    }

    protected override void LookRotation()
    {
        Quaternion rot;
        if (movement.magnitude > 0.2f)
        {
            rot = Quaternion.LookRotation(movement, Vector3.up);
            rgbd.rotation = rot;
        }
    }

    public void EnableControls()
    {
        playerControls.Player1.Enable();
    }

    public void DisableControls()
    {
        playerControls.Player1.Disable();
    }

    void ChangeState(Undead_State state)
    {
        GetComponent<UndeadStateManager>().SwitchState(state);
    }

}
