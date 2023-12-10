using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCCatchScript : MonoBehaviour
{
    public float npcSpeed;
    public Transform player;
    public Transform npcBackPlace;
    public Transform npcFinalPlace;
    public Transform npcStandby;
    public GameObject npcObject;
    public GameObject endGameObject;

    public Text warningText;
    public Text endText;
    public PlayerMoveScript playerMoveScript;
    public KeyCheckScript keyCheckScript;
    public AreaScript areaScript;
    public HideInVaseScript hideInVaseScript;
    public HideInPeopleScript hideInPeopleScript;
    public SFXScript sFXScript;
    
    int count=0;

    void Update()
    {
        if (keyCheckScript.keyTypeOne == true && areaScript.areaOneBool == true)
        {
            if (hideInVaseScript.isHide == false && hideInPeopleScript.isHide == false)
            {
                NPCFollow();

            }
            else if(hideInPeopleScript.isHide == true|| hideInVaseScript.isHide == true)
            {
                StartCoroutine(NPCWaitAndMoveBack());

            }
        }
        else if (keyCheckScript.keyTypeOne == false && areaScript.areaOneBool == true)
        {
            npcObject.transform.position = npcBackPlace.position;
        }
        else if (areaScript.areaTwoBool == true)
        {
            StartCoroutine(NPCWaitAndMoveBack());

        }
        else if (areaScript.areaThreeBool == true)
        {
            npcObject.transform.position = npcFinalPlace.position;

        }
    }
    /// <summary>
    /// NPC����
    /// </summary>
    void NPCFollow()
    {
        if (player != null&&playerMoveScript.canMove==true)
        {
            Vector2 direction = player.position - transform.position;
            direction.Normalize();
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, npcSpeed * Time.deltaTime);
            transform.position += (Vector3)direction * npcSpeed * Time.deltaTime;
        }
    }
    /// <summary>
    /// NPC���ݦ�m
    /// </summary>
    void NPCStandby()
    {
        Vector2 direction = npcStandby.position - transform.position;
        direction.Normalize();
        transform.position += (Vector3)direction * npcSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&&keyCheckScript.keyTypeOne==true)
        {
            sFXScript.laughSource.PlayOneShot(sFXScript.laughClip);
            endGameObject.SetActive(true);
            endText.text = "�Q���F!";

        }
        else if (collision.CompareTag("Player") && keyCheckScript.keyTypeOne == false)
        {
            HandleWarningText();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            warningText.text = "";
            count+=1;
        }
    }

    private void HandleWarningText()
    {
        if (count == 0)
        {
            warningText.text = "�o�Ӧ��~�H";

        }
        else if (count == 1)
        {
            warningText.text = "�٬O�����}�a!";

        }
        else if (count == 2)
        {
            warningText.text = "���I���ӹ�l";

        }
        else if (count == 3)
        {
            sFXScript.laughSource.PlayOneShot(sFXScript.laughClip);
            endGameObject.SetActive(true);
            endText.text = "�Q���F!";
        }
    }
    IEnumerator NPCWaitAndMoveBack()
    {
        yield return new WaitForSeconds(2f);
        NPCStandby();
    }
}
