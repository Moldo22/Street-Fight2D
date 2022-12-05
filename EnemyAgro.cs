using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgro : MonoBehaviour
{
    #region Inputs
    [SerializeField] Animator enemyAnim;
    [SerializeField] EnemyData enData1;
    [SerializeField] EnemyData enData2;
    [SerializeField] EnemyData PlayerData;
    [SerializeField] GameObject game;
    [SerializeField] GameObject game2;
    private Rigidbody2D rb;
    private Transform target;
    private GameObject obj;
    public static int limit=0;
    public static bool inRange=false;
    public static bool inRange2=false;
   
#endregion

private void AttackPlayer()
    {
        if (inRange) PlayerData.health-=enData1.hit;
        if (inRange2) PlayerData.health-=enData2.hit;
    }
private void FollowPlayer(){
    if (!AnimationEventHandler.pause)
    {
        obj.SetActive(false);
        if (target!=null)    //DeathPlayer Statement
        {
            if (Vector2.Distance(transform.position,target.position)>1.5f) //MinimumMovementRange
            {
                if (transform.position.x<target.position.x) 
                {
                    rb.velocity=transform.right*0.5f;
                    rb.transform.localScale=new Vector2(1.7f,1.7f);
                }
                else if(transform.position.x>target.position.x) 
                {
                    rb.velocity=transform.right*-(0.5f);
                    rb.transform.localScale=new Vector2(-1.7f,1.7f);
                }
            }
        }
    }
    else obj.SetActive(true);
}
private void AttackAnimation()
{
    if (target!=null)  //DeathPlayer Statement
    {
        if ((Vector2.Distance(transform.position,target.position)<1.5f)) enemyAnim.SetBool("Attacking",true);
        else enemyAnim.SetBool("Attacking",false);
    }
    else enemyAnim.SetBool("Attacking",false);
}

    #region Init
private void Start() {
    rb=GetComponent<Rigidbody2D>();
    obj=GameObject.Find("Canvas/Escape Menu");   
    if (Player.CurrentLevel==1 && limit<1)
    {
        enData1.level=1;
        enData2.level=1;
        limit++;
    }
    if (Player.CurrentLevel==enData1.level || Player.CurrentLevel==enData2.level)
    {  
        enData1.health=100;
        enData2.health=150;
    }
    else
    {
        enData1.health=-100;
        enData2.health=-150;
    }
}
#endregion

private void Die()
{
    PlayerData.hit+=5;
    if (enData1.health<=0 )   //DeadEnemy(Script1)
    {
        Destroy(game);
        inRange=false;
    }
    if (enData2.health<=0)   //DeadEnemy(Script2)
    {
        inRange2=false;
        Destroy(game2);
    }
}

private void Update() {
    
    //Death Animations Statement
    if (enData1.health<1) enemyAnim.SetBool("enemyDead",true);
    if (enData2.health<1) enemyAnim.SetBool("enemyDead2",true);
    if (PlayerData.health<0) Player.Dead=true;
    //
    if (target!=null)    //DeathPlayer Statement
    {
        if (Vector2.Distance(transform.position,target.position)<2f)   //MinimumAttackingRange
        {
            if (rb.name=="Enemy1") inRange=true;
            else if(rb.name=="Enemy2") inRange2=true;
        }
        else 
        {
            if (rb.name=="Enemy1") inRange=false;
            else if(rb.name=="Enemy2") inRange2=false;
        }
    }
}
private void FixedUpdate() {
    #region TargetPosition 
    try{
        target=FindObjectOfType<Player>().transform;
    }catch(NullReferenceException){};
#endregion

    #region EnemyAI
        FollowPlayer();
        AttackAnimation();
#endregion

    #region MovementAnimations
    if (target!=null)   //DeathPlayer Statement
    {
        if (AnimationEventHandler.pause) enemyAnim.SetFloat("enemyMovement",0);
        else 
            if (Vector2.Distance(transform.position,target.position)>1.5f) enemyAnim.SetFloat("enemyMovement",1);
            else enemyAnim.SetFloat("enemyMovement",0);
    }
    else enemyAnim.SetFloat("enemyMovement",0);
#endregion
}
}
