using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    [Header("���ʳt��")]
    public float speed;
    public Animator playeranimator;
    [Header("�n��")]
    public Joystick joystick;

    private Rigidbody2D playerRigidbody2D;
    public GameObject playerGameObject;
    public Collider2D playerCollider2D;
    public SpriteRenderer playerSpriteRender;

    public bool canMove = true;

    public LayerMask groundLayer;
    public AreaScript areaScript;
    public float jumpPower;

    public ReversedirectionScript reversedirectionScript;
    public GroundCheckScript groundCheckScript;
    public SFXScript sFXScript;
    

    void Start()
    {
        playeranimator = GetComponent<Animator>();
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerSpriteRender = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        

    }
    private void FixedUpdate()
    {
        if (canMove == true)
        {
            if (areaScript.areaOneBool == true)
            {
                playerRigidbody2D.gravityScale = 0;
                PlayerMove();
            }
            else if (areaScript.areaTwoBool == true)
            {
                playerRigidbody2D.gravityScale = 0;
                if (reversedirectionScript.reversedirectionBool == true)
                {
                    PlayerReversedirection();
                }
                else if(reversedirectionScript.reversedirectionBool==false)
                {
                    PlayerMove();
                }
                
            }
            else if (areaScript.areaThreeBool == true)
            {
                playerRigidbody2D.gravityScale = 3;
                playerGravityMove();
            }
        }
    }
    /// <summary>
    /// �}�Ⲿ��
    /// </summary>
    void PlayerMove()
    {
        
        float horizontalMove = joystick.Horizontal;
        float verticalMove = joystick.Vertical;
        bool isMoving = Mathf.Abs(horizontalMove) > 0 || Mathf.Abs(verticalMove) > 0;
        Vector3 movement = new Vector3(horizontalMove, verticalMove, 0) * Time.deltaTime * speed;
        if (horizontalMove > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (horizontalMove < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        playerRigidbody2D.MovePosition(playerRigidbody2D.position + new Vector2(horizontalMove, verticalMove) * Time.deltaTime * speed);
        playeranimator.SetFloat("Run", Mathf.Abs(horizontalMove) + Mathf.Abs(verticalMove));
        
        if (isMoving)
        {
            if (!sFXScript.runSource.isPlaying)
            {
                //�����n��
                sFXScript.runSource.PlayOneShot(sFXScript.runClip);
            }
        }
        else
        {
            // �p�G�S���n���J�A������n��
            sFXScript.runSource.Stop();
        }
    }
    /// <summary>
    /// �}�Ⲿ��(�ۤ�)
    /// </summary>
    void PlayerReversedirection()
    {
        float horizontalMove = -joystick.Horizontal;
        float verticalMove = -joystick.Vertical;
        bool isMoving = Mathf.Abs(horizontalMove) > 0 || Mathf.Abs(verticalMove) > 0;
        Vector3 movement = new Vector3(horizontalMove, verticalMove, 0) * Time.deltaTime * speed;
        if (horizontalMove > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (horizontalMove < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        playerRigidbody2D.MovePosition(playerRigidbody2D.position + new Vector2(horizontalMove, verticalMove) * Time.deltaTime * speed);
        playeranimator.SetFloat("Run", Mathf.Abs(horizontalMove) + Mathf.Abs(verticalMove));
       
        if (isMoving)
        {
            if (!sFXScript.runSource.isPlaying)
            {
                //�����n��
                sFXScript.runSource.PlayOneShot(sFXScript.runClip);
            }
        }
        else
        {
            // �p�G�S���n���J�A������n��
            sFXScript.runSource.Stop();
        }
    }
    /// <summary>
    /// �}�⥪�k����
    /// </summary>
    void playerGravityMove()
    {
        float horizontalMove = joystick.Horizontal;
        float verticalMove = -joystick.Vertical;
        bool isMoving = Mathf.Abs(horizontalMove) > 0 || Mathf.Abs(verticalMove) > 0;
        Vector2 monvement = new Vector2(horizontalMove, 0f);
        if (horizontalMove > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            playeranimator.SetFloat("Run", horizontalMove);
        }
        else if (horizontalMove < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            playeranimator.SetFloat("Run", -horizontalMove);
        }
        else if(horizontalMove == 0)
        {
            playeranimator.SetFloat("Run", 0);
        }
        playerRigidbody2D.velocity = new Vector2(monvement.x * speed, playerRigidbody2D.velocity.y);
        if (isMoving)
        {
            if (!sFXScript.runSource.isPlaying)
            {
                sFXScript.runSource.PlayOneShot(sFXScript.runClip);
            }
        }
        else
        {
            // �p�G�S���n���J�A������n��
            sFXScript.runSource.Stop();
        }

    }
    /// <summary>
    /// ���D
    /// </summary>
    public void Jump()
    {
        
        if (groundCheckScript.isGround)
        {
            sFXScript.jumpSource.PlayOneShot(sFXScript.jumpClip);
            //SFXScript.instance.jumpSource.PlayOneShot(SFXScript.instance.jumpClip);////��ҼҦ���
            playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x, jumpPower);
        }
    }
}
