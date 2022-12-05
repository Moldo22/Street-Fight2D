using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    #region helperReferences
    [SerializeField] GameObject Item;
    [SerializeField] EnemyData playerData;
    private GameObject DItem;
    private Vector3 randPos;
    private float Radius=1.1f;
    private int limit=0;
    private int counter;
    public static bool destroy=false;
    #endregion

private void SpawnObj()
{
    randPos= Random.insideUnitCircle * Radius;
    randPos.x=randPos.x*2;
    Debug.Log(randPos.y);
    DItem=Instantiate(Item,randPos,Quaternion.identity);
}

private void Despawn()
{
    Destroy(DItem);
}

private void OnDrawGizmos() 
{
    Gizmos.color=Color.green;
    Gizmos.DrawWireSphere(this.transform.position,Radius);
}

    void Update()
    {
        #region SpawningItem
        //Heart Trigger Statement
        if (destroy) 
        {
            playerData.health+=15;
            destroy=false;
            Despawn();
        }
        //
        if (playerData.health>125) limit=0;
        //Heart Spawn Statement
        if (playerData.health<125 && limit<1 && counter<3) 
        {
            SpawnObj();
            limit=1;
            counter++;
        }
        //
        #endregion
    }
}
