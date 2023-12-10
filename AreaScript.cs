using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaScript : MonoBehaviour
{
    public Collider2D areaOne;
    public Collider2D areaTwo;
    public Collider2D areaThree;
    public bool areaOneBool;
    public bool areaTwoBool;
    public bool areaThreeBool;

    public GameObject decorative;
    public GameObject medicineObject;
    public ReversedirectionScript reversedirectionScript;
    public Button jumpButton;
    private void Start()
    {
        jumpButton.gameObject.SetActive(false);
        decorative.SetActive(false);
        medicineObject.SetActive(false);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Area1"))
        {
            jumpButton.gameObject.SetActive(false);

            areaOneBool = true;
            areaTwoBool = false;
            areaThreeBool = false;
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Area2"))
        {
            jumpButton.gameObject.SetActive(false);

            areaOneBool = false;
            areaTwoBool = true;
            areaThreeBool = false;
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Area3"))
        {
            areaThreeBool = true;
            areaOneBool = false;
            areaTwoBool = false;
            jumpButton.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Area2"))
        {
            reversedirectionScript.reversedirectionBool = false;
        }
    }
}
