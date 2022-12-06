using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class Necrom_Range : MonoBehaviour
{
    public event Action<Undead_State> onOutOfRange;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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
}
