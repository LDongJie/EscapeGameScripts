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
            readComputerScript.explainText.text = "突然好累" + "\n" + "要快點離開了";
            mushroom.SetActive(false);
            StartCoroutine(WaitCloesText());
        }
    }
    IEnumerator WaitCloesText()
    {
        yield return new WaitForSeconds(1);
        readComputerScript.explainText.text = "移動方式改變";
       
        yield return new WaitForSeconds(2);
        readComputerScript.explainText.text = "";
       
    }
}
