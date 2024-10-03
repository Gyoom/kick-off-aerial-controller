using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour
{

    [SerializeField] private float radius = 10f;
    [SerializeField] private float power = 500f;

    [SerializeField] private LayerMask affectedLayers;

    public void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, affectedLayers);

        foreach (Collider hit in colliders) { 
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null) { 
                rb.AddExplosionForce(power, transform.position, radius);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);  
    }
}
