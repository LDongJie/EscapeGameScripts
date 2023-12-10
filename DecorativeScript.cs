using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorativeScript : MonoBehaviour
{
    public GameObject player;
    public Transform rebornPlace;
    private void Start()
    {

    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(WaitReborn());
            player.transform.position = rebornPlace.position;
        }
    }
    IEnumerator WaitReborn()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
