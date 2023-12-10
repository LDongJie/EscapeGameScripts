using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideInVaseScript : HideManagerScript
{
    public SpriteRenderer playerSpriteRenderer;
    protected override void OnHideButtonClick()
    {
        playerMoveScript.playerCollider2D.isTrigger = true;
        playerSpriteRenderer.sortingOrder = 0;
        playerMoveScript.playerGameObject.transform.position = hideTransform.transform.position;
        playerMoveScript.canMove = false;
        isHide = true;
        sFXScript.breathSource.PlayOneShot(sFXScript.breathClip);
        sFXScript.breathSource.loop = true;
        hideButton.gameObject.SetActive(true);
    }

    protected override void OnHideButtonExit()
    {
        playerSpriteRenderer.sortingOrder = 3;
        playerMoveScript.playerGameObject.transform.position = hideOutTransform.position;
        isHide = false;
        sFXScript.breathSource.loop = false;
        sFXScript.breathSource.Stop();
        playerMoveScript.canMove = true;
        hideButton.gameObject.SetActive(false);
        playerMoveScript.playerCollider2D.isTrigger = false;
    }
}
