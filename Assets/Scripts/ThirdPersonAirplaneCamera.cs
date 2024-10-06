using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonAirplaneCamera : MonoBehaviour
{

    [SerializeField] private GameObject airplane;
    [SerializeField] private CameraConfig config;
    [SerializeField] private float timeLerpPos = 0.1f;
    [SerializeField] private float timeLerpRot = 0.1f;

    [Header("Infos")]
    [SerializeField] private Vector3 currentVelocity;

    void FixedUpdate()
    {
        if (airplane) {
            // all directions camera follow
            Vector3 target = airplane.transform.position;
            target.z += config.posOffset.z;
            target.y += config.posOffset.y;
            transform.position  = Vector3.SmoothDamp(transform.position , target , ref currentVelocity , timeLerpPos);
            
            // Old - not efficient
            // transform.position = Vector3.Lerp(transform.position, airplane.transform.position + transform.forward * config.posOffset.z + transform.up * config.posOffset.y, timeLerpPos);
            
            // Alternative : forward camera follow
            //transform.position = Vector3.SmoothDamp(transform.position, airplane.transform.position + config.posOffset, ref velocity, config.timeOffset);
            
            Quaternion q = airplane.transform.rotation;
            transform.rotation = Quaternion.Lerp(transform.rotation, q, timeLerpRot);
        }
    }
}
