using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartGameScript : MonoBehaviour
{
    public GameObject startObject;
    public SFXScript sFXScript;

    public void StartGame()
    {
        sFXScript.buttonSource.PlayOneShot(sFXScript.buttonClip);
        startObject.SetActive(false);
    }
    public void RestartGame()
    {
        sFXScript.buttonSource.PlayOneShot(sFXScript.buttonClip);
        SceneManager.LoadScene("SampleScene");
    }
}
