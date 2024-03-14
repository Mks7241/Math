using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public GameObject questionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindAnyObjectByType<GroundSpawner>();
    }
    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        SpawnQuestion();
        Destroy(gameObject,4);
    }
    void SpawnQuestion()
    {
        Transform spawnPoint = transform.GetChild(2).transform;
        Instantiate(questionPrefab, spawnPoint.position,Quaternion.identity,transform);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
