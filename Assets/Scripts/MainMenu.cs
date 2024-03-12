using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionMenu;
    public GameObject levelSelectionMenu;
    // Start is called before the first frame update
    public void OnClickPlay()
    {
        levelSelectionMenu.SetActive(true);
    }
    public void OnClickOption()
    {
        optionMenu.SetActive(true);
    }
    public void OnClickBackOption()
    {
        optionMenu.SetActive(false);
    }
    public void OnClickExit()
    {
        Application.Quit();
    }

}
