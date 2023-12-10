using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenThreeScript : DoorOpenScript
{
    protected override bool CheckKeyType()
    {
        return keyCheckScript.keyTypeThree == true;
    }
}
