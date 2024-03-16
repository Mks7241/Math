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
        //SpawnQuestion();
        StartCoroutine(WaitForQuestionPrefab());
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            groundSpawner.SpawnTile();
            //SpawnQuestion();
            //wStartCoroutine(WaitForQuestionPrefab());
            Destroy(gameObject, 10);
        }
        
    }
    public IEnumerator WaitForQuestionPrefab()
    {
       // Debug.Log("waiting for question prefab");
        yield return new WaitForSeconds(2);
        SpawnQuestion() ;
        //Debug.Log("spawned");
    }
    public void SpawnQuestion()
    {
        Transform spawnPoint = transform.GetChild(2).transform;
        Instantiate(questionPrefab, spawnPoint.position,Quaternion.identity,transform);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
