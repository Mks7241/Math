using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void retry()
    {
        SceneManager.LoadScene(1);
    }
    public void OnClickMenu()
    {
        SceneManager.LoadScene(0);
    }
}
