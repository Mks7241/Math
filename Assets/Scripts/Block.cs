using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject completeBlock;
    [SerializeField] private GameObject brokenBlockPrefab;
    [SerializeField] private Rigidbody[] brokenPiecesRigidbodies; // Rigidbodies of broken pieces

   // [Header("SoundEffect")]
    //[SerializeField] private AudioSource breakSound;

    private void Start()
    {
        completeBlock.SetActive(true);
       // brokenBlockPrefab.SetActive(false);
    }

    // Method to break the block
    public void BreakBlock()
    {
        Debug.Log("blockBroken");
        //ParticleManager.Instance.PlayParticle(0, transform.position);
        completeBlock.SetActive(false);

        //breakSound.Play();
        GameObject brokenBlockInstance = Instantiate(brokenBlockPrefab, transform.position, transform.rotation);
        // Apply force to each broken piece to simulate movement
        foreach (var rb in brokenPiecesRigidbodies)
        {
            // Example: Apply force in a random direction
            rb.AddForce(Random.insideUnitSphere * 100f, ForceMode.Impulse);
        }
    }

    // Method to handle player collision
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("collided with block");
            //completeBlock.SetActive(false);
            //brokenBlock.SetActive(true);
            // Call BreakBlock() when the player passes through the correct answer block
            BreakBlock();
        }
    }
}


