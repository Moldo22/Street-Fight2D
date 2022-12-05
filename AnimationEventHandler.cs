using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{
    public static bool pause=false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) pause=true;
        if (Input.GetKeyDown(KeyCode.Return)) pause=false;
    }
}
