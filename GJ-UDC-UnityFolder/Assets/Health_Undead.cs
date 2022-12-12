using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Undead : Health
{
    protected override void Die()
    {
        GetComponent<UndeadStateManager>().SwitchState(Undead_State.UndeadDown);
        GetComponent<Mover_Player_Undead>().DisableControls();
    }

    protected override void Init()
    {
        base.Init();
        GetComponent<Mover_Player_Undead>().EnableControls();
    }


}
