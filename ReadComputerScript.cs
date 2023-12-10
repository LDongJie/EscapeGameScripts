using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadComputerScript : MonoBehaviour
{
    public Collider2D computerCollider2D;
    public Button readButton;
    public Text explainText;
    public Text buttonText;
    int readCount;

    public PlayerMoveScript playerMoveScript;
    public SFXScript sFXScript;
    void Start()
    {
        buttonText.text = "閱讀";
        readButton.gameObject.SetActive(false);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            readButton.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            readButton.gameObject.SetActive(false);
        }
    }
    public void ReadButtonControl()
    {
        sFXScript.buttonSource.PlayOneShot(sFXScript.buttonClip);
        if (readCount == 0)
        {
            buttonText.text = "確認";
            playerMoveScript.canMove = false;
            explainText.text = "小心不要碰到香菇";
            readCount = 1;
        }
        else if (readCount == 1)
        {
            explainText.text = "你可以躲在假人中" + "\n" + "或是花瓶裡";
            readCount = 2;
        }
        else if (readCount == 2)
        {
            explainText.text = "加油" + "\n" + "(再按確認離開)";
            readCount = 3;
        }
        else if (readCount == 3)
        {
            explainText.text = "";
            buttonText.text = "閱讀";
            readCount = 0;
            playerMoveScript.canMove = true;
        }

    }
}
