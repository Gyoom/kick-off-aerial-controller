using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class RocketBehaviour : MonoBehaviour
{
    private GameObject airplane;
    private float speed;  
    // Start is called before the first frame update
    void Start()
    {
        airplane = GameObject.FindGameObjectWithTag("airplane");
        speed = airplane.GetComponent<AirplaneController>().config.flySpeed * 1.3f;

        transform.LookAt(airplane.transform);
        StartCoroutine(SendHoming());
    }

    // Update is called once per frame
    public IEnumerator SendHoming()
    {
        while(Vector3.Distance(airplane.transform.position, transform.position)  > 0.3f)
        {
            Vector3 direction = airplane.transform.position - transform.position;
            direction = direction.normalized;
            transform.position += direction * speed * Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}
