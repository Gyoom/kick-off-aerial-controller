using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonAirplaneCamera : MonoBehaviour
{

    [SerializeField]
    private GameObject airplane;

    [SerializeField]
    private float verticalOutput = 4f;

    [SerializeField]
    private float horizontalOutput = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, airplane.transform.position - transform.forward * horizontalOutput + transform.up * verticalOutput, 5f * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, airplane.transform.rotation,  5f * Time.deltaTime);
    }
}
