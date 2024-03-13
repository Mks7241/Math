using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionMenu;
    public GameObject levelSelectionMenu;
    MenuAudioManager menuAudio;
    private void Start()
    {
        menuAudio = GameObject.FindGameObjectWithTag("MenuAudio").GetComponent<MenuAudioManager>();
       // menuAudio = GetComponent<MenuAudioManager>();
    }
    public void OnClickPlay()
    {
        levelSelectionMenu.SetActive(true);
        menuAudio.PlayMenuClickSound(menuAudio.click);
        
    }
    public void OnClickOption()
    {
        optionMenu.SetActive(true);
        menuAudio.PlayMenuClickSound(menuAudio.click);
    }
    public void OnClickBackOption()
    {
        optionMenu.SetActive(false);
        menuAudio.PlayMenuClickSound(menuAudio.click);
    }
    public void OnClickExit()
    {
        Application.Quit();
        menuAudio.PlayMenuClickSound(menuAudio.click);
    }

}
