using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    #region Inputs
    [SerializeField] private Animator animator;
    [SerializeField] EnemyData enData1;
    [SerializeField] EnemyData enData2;
    [SerializeField] EnemyData playerData;
    [SerializeField] GameObject RespawnBtn;
    private Rigidbody2D rb;
    private float movement;
    private float speed=2;
    private float jumpForce=7;
    public static bool onGround;
    private bool enemyCollision=false;
    public static bool Dead=false;
    public static bool OtherLevel=true;
    public static int CurrentLevel=1;
    #endregion
    
 private void AttackEnemy()
    {
        if (EnemyAgro.inRange) enData1.health-=playerData.hit;
        if (EnemyAgro.inRange2) enData2.health-=playerData.hit;
    }

    #region Init
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        //NPC Default
        gameObject.SetActive(true);
        playerData.health=200;
        playerData.hit=10+5*CurrentLevel;
        //
        if (OtherLevel) 
        {
            rb.transform.position=new Vector2(-8.66f,(-1.04f));
            rb.transform.localScale=new Vector2(-3,3);
        }
        else 
        {
            rb.transform.position=new Vector2(8.66f,(-1.04f));
            rb.transform.localScale=new Vector2(3,3);
        }
        }
#endregion

    #region Collsion
    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag=="Teren") onGround=true;
        if (col.gameObject.tag=="Enemy") enemyCollision=true;
    }

    private void OnCollisionExit2D(Collision2D col) {
        if (col.gameObject.tag=="Teren") onGround=false;
        if (col.gameObject.tag=="Enemy") enemyCollision=false;
    }
#endregion

private void Die() {
        gameObject.SetActive(false);
}   

    void Update()
    {
        if (playerData.health<1) RespawnBtn.SetActive(true);
        else RespawnBtn.SetActive(false);
        //Dead Animation Statement
        if (Dead) animator.SetBool("isDead",true);
        //
        #region PlayerInput
        //Animation Statement
        if (Input.GetKeyDown(KeyCode.Space)) animator.SetBool("Attack",true);
        else animator.SetBool("Attack",false);
        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)) movement=Mathf.Abs(Input.GetAxisRaw("Horizontal"));
        if (onGround || enemyCollision) animator.SetFloat("Move",movement);
        //
        if ((Input.GetKeyDown(KeyCode.W)) && onGround) rb.AddForce((Vector2.up*jumpForce),ForceMode2D.Impulse);
        else if (enemyCollision && (Input.GetKeyDown(KeyCode.W))) rb.AddForce((Vector2.up*jumpForce),ForceMode2D.Impulse);
        if (Input.GetKey(KeyCode.D) && (onGround || enemyCollision)) 
        {
            rb.velocity=transform.right*speed;
            transform.localScale=new Vector2(-3,3);
        }
        if (Input.GetKey(KeyCode.A) && (onGround || enemyCollision)) 
        {
            rb.velocity=transform.right*-1*speed;
            transform.localScale=new Vector2(3,3);
        }
        #endregion
    }
}
