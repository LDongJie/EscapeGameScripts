using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenOneScript : DoorOpenScript
{
    protected override bool CheckKeyType()
    {
        return keyCheckScript.keyTypeOne == true;
    }
}
