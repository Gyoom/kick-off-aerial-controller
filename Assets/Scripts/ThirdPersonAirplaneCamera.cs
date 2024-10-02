using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonAirplaneCamera : MonoBehaviour
{

    [SerializeField]
    private GameObject airplane;

    [SerializeField]
    private CameraConfig config;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, airplane.transform.position - transform.forward * config.horizontalOffset + transform.up * config.verticalOffset, config.lag * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, airplane.transform.rotation,  config.lag * Time.deltaTime);
    }
}
