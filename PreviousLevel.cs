using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviousLevel : MonoBehaviour
{
    #region helperReferences
    private Rigidbody2D rbd;
    [SerializeField] EnemyData e1;
    [SerializeField] EnemyData e2;
    public static bool prevLevel=false;
    #endregion

    #region PreviousLevelTrigger
    private void OnTriggerEnter2D(Collider2D col2) {
        if (col2.gameObject.tag=="PreviousLevel") 
        {
            SceneSelecting.PreviousLevel();
            Player.OtherLevel=false;
            e1.level-=1;
            e2.level-=1;
            prevLevel=true;
        }
    }
    #endregion

    #region Init
    void Start()
    {
        rbd=GetComponent<Rigidbody2D>();
    }
    #endregion
}
