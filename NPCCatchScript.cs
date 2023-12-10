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
    /// NPC跟蹤
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
    /// NPC等待位置
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
            endText.text = "被抓住了!";

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
            warningText.text = "這個有嚇人";

        }
        else if (count == 1)
        {
            warningText.text = "還是快離開吧!";

        }
        else if (count == 2)
        {
            warningText.text = "有點不太對勁";

        }
        else if (count == 3)
        {
            sFXScript.laughSource.PlayOneShot(sFXScript.laughClip);
            endGameObject.SetActive(true);
            endText.text = "被抓住了!";
        }
    }
    IEnumerator NPCWaitAndMoveBack()
    {
        yield return new WaitForSeconds(2f);
        NPCStandby();
    }
}
