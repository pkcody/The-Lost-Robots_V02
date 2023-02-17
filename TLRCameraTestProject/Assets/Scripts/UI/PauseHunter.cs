using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseHunter : MonoBehaviour
{
    [HideInInspector] public GameObject pauseMenu;
    [HideInInspector] public GameObject settingsMenu;
    [HideInInspector] public GameObject mainMenu;
    [HideInInspector] public GameObject pauseSettingsButton;

    private void Start()
    {
        PauseHunt();
    }


    public void PauseHunt()
    {
        if(pauseMenu == null || settingsMenu == null || mainMenu == null)
        {
            foreach(GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
            {
                if (SceneManager.GetActiveScene().name == "Game")
                {
                    if (go.name == "SettingsBG")
                    {
                        settingsMenu = go;
                    }
                    if (go.name == "Settings")
                    {
                        pauseSettingsButton = go;
                    }

                }
                else if (SceneManager.GetActiveScene().name == "MainMenu")
                {
                    if (go.name == "Settings")
                    {
                        settingsMenu = go;
                    }

                }

                if (go.name == "MainMenuButtons")
                {
                    mainMenu = go;
                }
                //if (go.name == "SettingsBG")
                //{
                //    pauseMenu = go;
                //}
            }
        }
        foreach (PauseGameMenu pgm in FindObjectsOfType<PauseGameMenu>())
        {
            if(pgm.pauseGameMenu == null || settingsMenu == null)
            {
                if(SceneManager.GetActiveScene().name != "MainMenu")
                {
                    pgm.pauseGameMenu = gameObject;
                    pgm.TopButtonOnSettings = pauseSettingsButton;
                }
                
                pgm.settingsMenu = settingsMenu;
            }

            if(SceneManager.GetActiveScene().name == "MainMenu")
            {
                pgm.mainMenu = mainMenu;
            }
            
        }

        if(SceneManager.GetActiveScene().name != "MainMenu" && SceneManager.GetActiveScene().name != "Join")
        {
            gameObject.SetActive(false);
        }
    }
}
