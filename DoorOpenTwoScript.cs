using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenTwoScript : DoorOpenScript
{
    protected override bool CheckKeyType()
    {
        return keyCheckScript.keyTypeTwo == true;
    }
}
