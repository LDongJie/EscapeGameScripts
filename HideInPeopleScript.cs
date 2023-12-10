using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideInPeopleScript : HideManagerScript
{
    public GameObject hidePerson;
    SpriteRenderer spriteRenderer;
    public Sprite personHideSprite;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
       
    }
    /// <summary>
    /// ¸úÂÃ
    /// </summary>
    protected override void OnHideButtonClick()
    {
        playerMoveScript.playerGameObject.transform.position = hidePerson.transform.position;
        playerMoveScript.canMove = false;
        isHide = true;
        sFXScript.breathSource.PlayOneShot(sFXScript.breathClip);
        sFXScript.breathSource.loop = true;
        hideButton.gameObject.SetActive(true);
    }
    /// <summary>
    /// Â÷¶}¸úÂÃ
    /// </summary>
    protected override void OnHideButtonExit()
    {
        playerMoveScript.playerGameObject.transform.position = hideOutTransform.position;
        isHide = false;
        sFXScript.breathSource.loop = false;
        sFXScript.breathSource.Stop();
        playerMoveScript.canMove = true;
        hideButton.gameObject.SetActive(false);
        playerMoveScript.playerCollider2D.isTrigger = false;
    }
}
