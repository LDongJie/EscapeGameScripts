using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenScript : ExplainTextScript
{
    public GameObject door;
    public Sprite closeSprite;
    public Sprite openSprite;
    public SpriteRenderer doorSprite;
    public Collider2D doorCollider;
    public SFXScript sFXScript;
    public bool doorType = false;
    public KeyCheckScript keyCheckScript;

    protected virtual bool CheckKeyType()
    {
        return false;
    }

    protected virtual void PlayDoorSound(bool canOpen)
    {
        if (canOpen)
        {
            sFXScript.doorSource.PlayOneShot(sFXScript.doorClip);
        }
        else
        {
            sFXScript.doorCantSource.PlayOneShot(sFXScript.doorCantClip);
        }
    }

    private void Start()
    {
        doorSprite = door.GetComponent<SpriteRenderer>();
        doorCollider = door.GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (doorType == false)
        {
            if (collision.CompareTag("Player") && CheckKeyType())
            {
                doorSprite.sprite = openSprite;
                doorType = true;
                doorCollider.isTrigger = true;
                PlayDoorSound(true);
            }
            else if (collision.CompareTag("Player") && !CheckKeyType())
            {
                explainText.text = "Æ_°Í©O";
                StartCoroutine(WaitTextNull());
                PlayDoorSound(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && CheckKeyType())
        {
            doorSprite.sprite = closeSprite;
            doorCollider.isTrigger = false;
            doorType = false;
        }
    }

    private IEnumerator WaitTextNull()
    {
        yield return new WaitForSeconds(1.5f);
        explainText.text = "";
    }
}
