using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Undead : Health
{
    public override void Die()
    {
        GetComponent<UndeadStateManager>().SwitchState(Undead_State.UndeadDown);
        GetComponent<PlayerTwoMovements>().DisableControls();
    }

    public override void Init()
    {
        base.Init();
        GetComponent<PlayerTwoMovements>().EnableControls();
    }


}
