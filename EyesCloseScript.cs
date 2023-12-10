using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesCloseScript : MonoBehaviour
{
    public ReadComputerScript readComputerScript;
    public GameObject mushroom;
    public GameObject eyesImages;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mushroom"))
        {
            eyesImages.SetActive(true);
            readComputerScript.explainText.text = "��M�n��" + "\n" + "�n���I���}�F";
            mushroom.SetActive(false);
            StartCoroutine(WaitCloesText());
        }
    }
    IEnumerator WaitCloesText()
    {
        yield return new WaitForSeconds(1);
        readComputerScript.explainText.text = "���ʤ覡����";
       
        yield return new WaitForSeconds(2);
        readComputerScript.explainText.text = "";
       
    }
}
