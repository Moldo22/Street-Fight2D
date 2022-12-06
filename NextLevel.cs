using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    #region helperReferences
    [SerializeField] EnemyData e1;
    [SerializeField] EnemyData e2;
    private Rigidbody2D rbd;
    private bool Next=false;
    private Player pl;
    #endregion

    #region NextLevelTrigger
    private void OnTriggerEnter2D(Collider2D col2) {
        if ((col2.gameObject.tag=="NextLevel") && Next) 
        {
            SceneSelecting.NextLevel();
            Player.OtherLevel=true;
            if(!PreviousLevel.prevLevel) Player.CurrentLevel++;
            e1.level+=1;
            e2.level+=1;
            if (e1.level==2) 
            {
                e1.hit*=2;
                e1.health=e1.health+50;
            }
            PreviousLevel.prevLevel=false;
        }
    }
    #endregion

    #region Init
    void Start()
    {
        rbd=GetComponent<Rigidbody2D>();
    }
    #endregion

    void Update()
    {
        //Death NPCs statement
        if ((e1.health<1) && (e2.health<1)) Next=true;
        //
    }
}
