using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulCounter : MonoBehaviour
{
    [SerializeField]
    private int soulCount = 0;

    public event Action<string> ATextUpdate;


    // Start is called before the first frame update
    void Start()
    {
        ATextUpdate?.Invoke(soulCount.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToSoulCount()
    {
        soulCount++;
        ATextUpdate?.Invoke(soulCount.ToString());
    }

    void ResetSouls()
    {
        soulCount = 0;
        ATextUpdate?.Invoke(soulCount.ToString());

    }

    void DistributeSouls()
    {
        //player.CollectSouls(soulCount)
        ResetSouls();
    }

}
