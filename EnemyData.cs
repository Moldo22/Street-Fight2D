using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Street Fight/EnemyData", order = 0)]
public class EnemyData : ScriptableObject {
    
   #region ScriptableObjectInput 
    public int health;
    public int hit;
    public int level;
    #endregion
}
