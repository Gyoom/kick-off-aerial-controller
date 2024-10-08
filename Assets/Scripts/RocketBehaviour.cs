using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class RocketBehaviour : MonoBehaviour
{
    [SerializeField] private float timeLerpRot = 0.1f;

    private GameObject airplane;
    private float speed;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        airplane = GameObject.FindGameObjectWithTag("airplane");
        speed = airplane.GetComponent<AirplaneController>().config.flySpeed * 1.5f;
        rb = gameObject.GetComponent<Rigidbody>();

        transform.LookAt(airplane.transform);
        StartCoroutine(SendRocket());
    }

    // Update is called once per frame
    private IEnumerator SendRocket()
    {
        while(airplane != null && Vector3.Distance(airplane.transform.position, transform.position)  > 0.3f)
        {
            Vector3 direction = airplane.transform.position - transform.position;
            direction.x = direction.x / 6;
            direction = direction.normalized;
            Quaternion airplaneRotation = airplane.transform.rotation;

            transform.rotation = Quaternion.Lerp(transform.rotation, airplaneRotation, timeLerpRot);
            rb.velocity = direction * speed;

            yield return null;
        }
        Destroy(gameObject);
    }
}
