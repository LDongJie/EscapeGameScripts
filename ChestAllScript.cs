using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAllScript : ExplainTextScript
{
    public Collider2D chestCollider;
    public GameObject chest;
    public Sprite chestOpenSprite;
    public Sprite chestCloseSprite;
    public SpriteRenderer chestRender;
    internal bool chestBool;

    public GameObject decorativeObject;
    public KeyCheckScript keyCheckScript;
    public SFXScript sFXScript;
    public PlayerMoveScript playerMoveScript;

    private void Start()
    {
        chestRender = chest.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (keyCheckScript.keyTypeOne == false)
            {
                OpenChest("�����_�ͤF�ֶ]", 1);
            }
            else if (keyCheckScript.keyTypeTwo == false)
            {
                OpenChest("�o��@���_��\n\"�p�߾ާ@��V�ۤ�\"", 2, () => StartCoroutine(WaitMove(2)));
            }
            else if (keyCheckScript.keyTypeThree == false)
            {
                OpenChest("�ש󮳨�̫�@���_�ͤF", 3);
            }
            else
            {
                explainText.text = "�̭��ŤF";
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && (keyCheckScript.keyTypeOne || keyCheckScript.keyTypeTwo || keyCheckScript.keyTypeThree))
        {
            explainText.text = "";
        }
    }

    void OpenChest(string message, int keyType, System.Action extraAction = null)
    {
        chestRender.sprite = chestOpenSprite;
        chestBool = true;
        sFXScript.chestSource.PlayOneShot(sFXScript.chestClip);

        if (extraAction != null)
        {
            extraAction.Invoke();
        }
        else
        {
            explainText.text = message;
            StartCoroutine(WaitKeyType(keyType));
        }
    }

    IEnumerator WaitKeyType(int keyType)
    {
        yield return new WaitForSeconds(1);

        switch (keyType)
        {
            case 1:
                keyCheckScript.keyTypeOne = true;
                break;
            case 2:
                keyCheckScript.keyTypeTwo = true;
                break;
            case 3:
                keyCheckScript.keyTypeThree = true;
                break;
        }

        explainText.text = "";
    }

    IEnumerator WaitMove(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        playerMoveScript.canMove = true;
        explainText.text = "";
    }
}
