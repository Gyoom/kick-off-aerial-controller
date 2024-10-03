using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonAirplaneCamera : MonoBehaviour
{

    [SerializeField] private GameObject airplane;
    [SerializeField] private CameraConfig config;
    [Header("Infos")]
    [SerializeField] private Vector3 currentVelocity;

    void LateUpdate()
    {
        if (airplane != null) {
            // all direction camera follow
            transform.position = Vector3.Lerp(transform.position, airplane.transform.position + transform.forward * config.posOffset.z + transform.up * config.posOffset.y, 5f * Time.deltaTime);
            Quaternion q1 = Quaternion.Euler(airplane.transform.rotation.x, airplane.transform.rotation.y, airplane.transform.rotation.z);
            Quaternion q = airplane.transform.rotation;
            //q.z = 0;
            transform.rotation = Quaternion.Lerp(transform.rotation, q, 5f * Time.deltaTime);

            // forward camera follow
            //transform.position = Vector3.SmoothDamp(transform.position, airplane.transform.position + config.posOffset, ref velocity, config.timeOffset);
        }
    }
}
