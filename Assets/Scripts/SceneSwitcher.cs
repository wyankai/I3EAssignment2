/******************************************************************************
Author: Syakir(S10204929) and Yankai(S10206089)

Name of Class: SceneSwitcher

Description of Class: This class help to switch between the scenes in unity

Date Created: 17/07/2021
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void Game()
    {
        SceneManager.LoadScene("Game");
    }
    public void playCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void howToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void options()
    {
        SceneManager.LoadScene("Options");
    }

    public void startMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void Ending()
    {
        SceneManager.LoadScene("Ending");
    }

    public void quit()
    {
        Application.Quit();
    }
}
