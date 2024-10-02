using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    [SerializeField] private float flySpeed = 5;
    [SerializeField] private float yawAmount = 120;
    
    private float yaw;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * flySpeed  * Time.deltaTime;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        yaw += horizontalInput * yawAmount * Time.deltaTime;
        float pitch = Mathf.Lerp(0, 60, Mathf.Abs(verticalInput)) * -Mathf.Sign(verticalInput);
        float roll = Mathf.Lerp(0, 30, Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput);

        transform.localRotation = Quaternion.Euler(Vector3.up * yaw + Vector3.right * pitch + Vector3.forward * roll);
    }
}
