using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectionManager : MonoBehaviour
{
    MenuAudioManager mAudioManager;
    private void Start()
    {
        mAudioManager = GameObject.FindGameObjectWithTag("MenuAudio").GetComponent<MenuAudioManager>();
    }
    public void OnClickBack()
    {
        mAudioManager.PlayMenuClickSound(mAudioManager.click);
        this.gameObject.SetActive(false);
    }
    public void LevelSelection(int level)
    {
        SceneManager.LoadScene(level);
        mAudioManager.PlayMenuClickSound(mAudioManager.click);
    }
}
