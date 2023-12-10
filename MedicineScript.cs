using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineScript : MonoBehaviour
{
    public GameObject medicine;
    public ReversedirectionScript reversedirectionScript;
    public PlayerMoveScript playerMoveScript;
    public SFXScript sFXScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerMoveScript.canMove = false;
            playerMoveScript.playeranimator.SetFloat("Run", 0);
            reversedirectionScript.reversedirectionBool = false;
            sFXScript.drinkSource.PlayOneShot(sFXScript.drinkClip);
            reversedirectionScript.explianText.text = "獲得解藥" + "\n" + "操作恢復正常";
            StartCoroutine(WaitSecond());
        }
    }
    IEnumerator WaitSecond()
    {
        yield return new WaitForSeconds(1);
        playerMoveScript.canMove = true;
        medicine.SetActive(false);
        reversedirectionScript.explianText.text = "";
    }
}
