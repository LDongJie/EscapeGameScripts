using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestThirdScript : ChestManagerScript
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OpenChest(keyCheckScript.keyTypeThree, chestOpenSprite, "�ש󮳨�̫�@���_�ͤF");
            keyCheckScript.keyTypeThree = true;
        }
    }
}
