using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectionManager : MonoBehaviour
{
    public void OnClickBack()
    {
        this.gameObject.SetActive(false);
    }
    public void LevelSelection(int level)
    {
        SceneManager.LoadScene(level);
    }
}
