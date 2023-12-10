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
        buttonText.text = "�\Ū";
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
            buttonText.text = "�T�{";
            playerMoveScript.canMove = false;
            explainText.text = "�p�ߤ��n�I�쭻ۣ";
            readCount = 1;
        }
        else if (readCount == 1)
        {
            explainText.text = "�A�i�H���b���H��" + "\n" + "�άO��~��";
            readCount = 2;
        }
        else if (readCount == 2)
        {
            explainText.text = "�[�o" + "\n" + "(�A���T�{���})";
            readCount = 3;
        }
        else if (readCount == 3)
        {
            explainText.text = "";
            buttonText.text = "�\Ū";
            readCount = 0;
            playerMoveScript.canMove = true;
        }

    }
}
