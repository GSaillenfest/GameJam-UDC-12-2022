using System;
using UnityEngine;
using UnityEngine.InputSystem;

    [RequireComponent(typeof(Rigidbody))]
public class PlayerOneMovements : MonoBehaviour
{
    [SerializeField]
    float speed = 2f;
    Rigidbody rgbd;
    public PlayerControls playerControls;
    Vector2 move;
    Vector3 movement;

    private void Awake()
    {
        playerControls = new();
        rgbd = GetComponent<Rigidbody>();
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
        move = playerControls.Player.Move.ReadValue<Vector2>();
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
        movement = speed * movement.normalized;
        rgbd.velocity = movement;
    }
    private void LookRotation()
    {
        Quaternion rot;
        if (movement.magnitude > 0.2f)
        {
            rot = Quaternion.LookRotation(movement, Vector3.up);
            rgbd.rotation = rot;
        }
    }

    private void EnableControls()
    {
        playerControls.Player.Enable();
    }

    private void DisableControls()
    {
        playerControls.Player.Disable();
    }

    void ChangeState(Undead_State state)
    {
        Debug.Log("changing state ?");
        GetComponent<UndeadStateManager>().SwitchState(state);
    }

}
