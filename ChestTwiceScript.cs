using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestTwiceScript : ChestManagerScript
{
    public GameObject decorativeObject;
    public GameObject medicineObject;
    public PlayerMoveScript playerMoveScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OpenChest(keyCheckScript.keyTypeTwo, chestOpenSprite, "�o��@���_��\n\"�p�߾ާ@��V�ۤ�\"");
            if (keyCheckScript.keyTypeTwo==false)
            {
                playerMoveScript.canMove = false;
                playerMoveScript.playeranimator.SetFloat("Run", 0);
                keyCheckScript.keyTypeTwo = true;
                medicineObject.SetActive(true);
                decorativeObject.SetActive(true);
                StartCoroutine(WaitMove());
            }
        }
    }

    private IEnumerator WaitMove()
    {
        yield return new WaitForSeconds(2);
        playerMoveScript.canMove = true;
    }
}
