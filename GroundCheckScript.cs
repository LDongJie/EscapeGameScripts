using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckScript : MonoBehaviour
{
    public bool isGround;
    Collider2D groundcollider2D;
    void Start()
    {
        groundcollider2D = GetComponent<Collider2D>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer==LayerMask.NameToLayer("Ground"))
        {
            isGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGround = false;
        }
    }
}
