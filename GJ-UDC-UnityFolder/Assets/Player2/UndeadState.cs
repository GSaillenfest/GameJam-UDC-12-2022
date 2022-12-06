using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="UndeadState", menuName ="State/Undead", order =0)]
public class UndeadState : ScriptableObject
{
    [SerializeField]
    protected float _speed;
    [SerializeField]
    protected float _damages;

    public float Speed { get { return _speed; } }

    public virtual void OnStateEnter()
    {

    }
    
    public virtual void OnStateExit()
    {

    }
    
    public virtual void OnStateUpdate()
    {

    }

}
