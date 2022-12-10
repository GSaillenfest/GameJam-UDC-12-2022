using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColliderState
{
    Closed,
    Open,
    OnCollision
}

public interface IHitboxResponder
{
    void CollisionedWith(Collider collider);
}


public class HitBox : MonoBehaviour
{
    [SerializeField]
    Vector3 position;
    [SerializeField]
    Vector3 boxSize;
    [SerializeField]
    Quaternion rotation;
    [SerializeField]
    LayerMask mask;
    [SerializeField]
    ParticleSystem vfx;

    Color[] color = new Color[3] { Color.yellow, Color.green, Color.red };
    ColliderState _state = ColliderState.Closed;
    IHitboxResponder _responder = null;

    public void useResponder(IHitboxResponder responder)
    {
        _responder = responder;
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        if (_state == ColliderState.Closed) return;

        Collider[] colliders = Physics.OverlapBox(position, boxSize, rotation, mask);

        if (colliders.Length > 0)
        {
            _state = ColliderState.OnCollision;
            Collider collider = colliders[0];
            _responder?.CollisionedWith(collider);
            if (vfx != null)
                vfx.Play();
        }
        else _state = ColliderState.Open;


    }

    private void CheckForGizmoColor()
    {
        switch (_state)
        {
            case ColliderState.Closed:
                Gizmos.color = color[0];
                break;
            case ColliderState.Open:
                Gizmos.color = color[1];
                break;
            case ColliderState.OnCollision:
                Gizmos.color = color[2];
                break;
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        CheckForGizmoColor();
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawCube(Vector3.zero, boxSize * 2);
    }

    public void EnableCheckCollision()
    {
        _state = ColliderState.Open;
    }
    
    public void DisableCheckCollision()
    {
        _state = ColliderState.Closed;
    }
}

