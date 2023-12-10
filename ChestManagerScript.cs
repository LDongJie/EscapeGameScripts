using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManagerScript : ExplainTextScript
{
    public Collider2D chestCollider;
    public GameObject chest;
    public Sprite chestOpenSprite;
    public Sprite chestCloseSprite;
    public SpriteRenderer chestRender;
    internal bool chestBool;

    public KeyCheckScript keyCheckScript;
    public SFXScript sFXScript;

    private void Start()
    {
        chestRender = chest.GetComponent<SpriteRenderer>();
    }

    protected void OpenChest(bool keyType, Sprite openSprite, string explanation)
    {
        if (keyType == false)
        {
            chestRender.sprite = openSprite;
            chestBool = true;
            sFXScript.chestSource.PlayOneShot(sFXScript.chestClip);
            explainText.text = explanation;
            StartCoroutine(WaitTextNull());
        }
        else if(keyType == true)
        {
            explainText.text = "裡面空了";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            explainText.text = "";
        }
    }

    private IEnumerator WaitTextNull()
    {
        yield return new WaitForSeconds(1.5f);
        explainText.text = "";
    }

}

