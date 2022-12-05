using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
  #region HeartDespawnTrigger
  private void OnTriggerEnter2D(Collider2D col) {
    if (col.CompareTag("Player")) RandomSpawner.destroy=true;
}
private void OnTriggerExit2D(Collider2D col) {
    if (col.gameObject.tag=="Player") Debug.Log("Bye");
}
  #endregion
}
