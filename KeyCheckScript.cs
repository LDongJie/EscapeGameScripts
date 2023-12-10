using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCheckScript : MonoBehaviour
{
    public bool keyTypeOne;
    public bool keyTypeTwo;
    public bool keyTypeThree;
    public GameObject key;
    public ChestManagerScript chestManagerScript;
    void Start()
    {
        key.transform.localScale = new Vector2(0, 0);
        StartCoroutine(GotKey());
    }

    void Update()
    {

    }
    IEnumerator GotKey()
    {
        while(chestManagerScript.chestBool != true)
        {
            key.transform.localScale = new Vector2(0, 0);
            yield return null;
        }
        //yield return new WaitForSeconds(0.5f);
        chestManagerScript.chestBool = false;
        key.transform.localScale = new Vector3(0.5f, 0.5f,1);
        yield return new WaitForSeconds(2);
        key.transform.localScale = new Vector2(0, 0);
    }
}
