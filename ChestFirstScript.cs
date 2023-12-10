using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestFirstScript : ChestManagerScript
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sFXScript.npcWakeUpSource.PlayOneShot(sFXScript.npcWakeUpClip);
            OpenChest(keyCheckScript.keyTypeOne, chestOpenSprite, "�����_�ͤF~�ֶ]!");
            keyCheckScript.keyTypeOne = true;
        }
    }
}
