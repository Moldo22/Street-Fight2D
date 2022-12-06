using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelecting : MonoBehaviour
{
    #region ScenesWindow
    public static void Start()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public static void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public static void PreviousLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }

    public static void Restart()
    {
        try
        {
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-2);
        }catch(Exception){};
        try
        {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        }catch(Exception){};
    }

    public static void Quit() {
        Application.Quit();
    }
    #endregion
}
