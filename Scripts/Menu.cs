using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //This class pertains to any scene loading or changing
    public void GoToMain()
    {
        //Load Main Menu
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void RestartLevel1()
    {
        //Load Summer
        SceneManager.LoadScene(4);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadLevel0()
    {
        //Load Tutorial
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }

    public void LoadLevel1()
    {
        //Load Summer
        SceneManager.LoadScene(4);
        Time.timeScale = 1;
    }

    public void LoadLevel2()
    {
        //Load SummerNight
        SceneManager.LoadScene(5);
        Time.timeScale = 1;
    }

    public void LoadLevel3()
    {
        //Load Fall
        SceneManager.LoadScene(6);
        Time.timeScale = 1;
    }

    public void LoadLevel4()
    {
        //Load FallNight
        SceneManager.LoadScene(7);
        Time.timeScale = 1;
    }
    public void LoadLevel5()
    {
        //Load FallNight
        SceneManager.LoadScene(8);
        Time.timeScale = 1;
    }
    public void LoadLevel6()
    {
        //Load FallNight
        SceneManager.LoadScene(9);
        Time.timeScale = 1;
    }

    public void LevelSelect()
    {
        //Load Level Select
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
}
