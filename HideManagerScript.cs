using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HideManagerScript : MonoBehaviour
{
    public Collider2D hideCollider2D;
    public Transform hideTransform;
    public Transform hideOutTransform;
    public PlayerMoveScript playerMoveScript;
    public Button hideButton;
    public bool isHide;
    public SFXScript sFXScript;

    void Start()
    {
        hideButton.gameObject.SetActive(false);
    }

    void Update()
    {
        if (playerMoveScript.canMove == true)
        {
            isHide = false;
        }
    }

    // 通用的觸發進入邏輯
    protected void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isHide == false)
        {
            hideButton.gameObject.SetActive(true);
            hideButton.onClick.AddListener(delegate ()
            {
                OnHideButtonClick();
            });
        }
        else if (collision.CompareTag("Player") && isHide == true)
        {
            hideButton.onClick.AddListener(delegate ()
            {
                OnHideButtonExit();
            });
        }
    }

    // 通用的觸發離開邏輯
    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hideButton.gameObject.SetActive(false);
        }
    }

    // 隱藏按鈕點擊時的處理邏輯，需在子類中實現
    protected virtual void OnHideButtonClick()
    {
        // 空實現，需要在子類中實現
    }

    // 隱藏按鈕離開時的處理邏輯，需在子類中實現
    protected virtual void OnHideButtonExit()
    {
        // 空實現，需要在子類中實現
    }

}
