using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScript : MonoBehaviour
{
    public GameObject endText;
    public PlayerMoveScript playerMoveScript;
    public SFXScript sFXScript;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            endText.SetActive(true);
            playerMoveScript.canMove = false;
        }
    }
    public void QuitGame()
    {
        sFXScript.buttonSource.PlayOneShot(sFXScript.buttonClip);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
