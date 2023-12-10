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

    // �q�Ϊ�Ĳ�o�i�J�޿�
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

    // �q�Ϊ�Ĳ�o���}�޿�
    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hideButton.gameObject.SetActive(false);
        }
    }

    // ���ë��s�I���ɪ��B�z�޿�A�ݦb�l������{
    protected virtual void OnHideButtonClick()
    {
        // �Ź�{�A�ݭn�b�l������{
    }

    // ���ë��s���}�ɪ��B�z�޿�A�ݦb�l������{
    protected virtual void OnHideButtonExit()
    {
        // �Ź�{�A�ݭn�b�l������{
    }

}
