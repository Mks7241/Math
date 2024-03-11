using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Break : MonoBehaviour
{
    public Rigidbody rb;
    public bool isbroken;
    public float scatterForce = 10f;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isbroken)
        {
            if (isbroken == true)
            {
                rb.isKinematic = false;
                Invoke("DestroyPiece", 3);
                Scatter();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        bool v = other.CompareTag("Player");
        if (v)
        {          
            isbroken = true;
        }
    }
    private void DistroyPiece()
    {
        Destroy(this.gameObject);
    }
    private void Scatter()
    {
        // Apply scatter force to the broken piece in random directions
        Collider playerCollider = player.GetComponent<Collider>();
        Physics.IgnoreCollision(GetComponent<Collider>(), playerCollider);

        Vector3 scatterDirection = Random.insideUnitSphere.normalized;
        rb.AddForce(scatterDirection * scatterForce, ForceMode.Impulse);
    }
}
