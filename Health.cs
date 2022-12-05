using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    #region helperReferences
    [SerializeField] EnemyData Player;
    [SerializeField] GameObject Heart;
    [SerializeField] GameObject Heart2;
    [SerializeField] GameObject Heart3;
    [SerializeField] GameObject Heart4;
    #endregion
    void Update()
    {
        #region HeartsDespawnStatement
        if (Player.health<150) Destroy(Heart4);
        if (Player.health<100) Destroy(Heart3);
        if (Player.health<50) Destroy(Heart2);
        if (Player.health<0) Destroy(Heart);
        #endregion
    }
}
