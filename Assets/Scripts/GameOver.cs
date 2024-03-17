using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject player;
    public GameObject gameOver;
    public GameObject playerPref;
    PlayerController playerController;
    Animator animator;
    public void retry()
    {
       SceneManager.LoadScene(1);
       //Vector3 respawnPosition = new Vector3 (player.transform.position.x,player.transform.position.y,player.transform.position.z);
       

       




    }
    public void OnClickMenu()
    {
        SceneManager.LoadScene(0);
    }
}
