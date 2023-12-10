using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReversedirectionScript : MonoBehaviour
{
    public Text explianText;
    public GameObject mushroom;
    public bool reversedirectionBool;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            reversedirectionBool = true;
            mushroom.SetActive(false);
        }
    }

}
