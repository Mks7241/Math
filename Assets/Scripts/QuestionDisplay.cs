using UnityEngine;

public class QuestionDisplay : MonoBehaviour
{
    public GameObject questionText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            questionText.SetActive(true);
        }
    }
}