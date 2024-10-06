using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class AirplaneController : MonoBehaviour
{
    [Header("Activation features")]
    [SerializeField] private bool forwardControl;
    public bool isStarted = false;
    public bool canTurn = false;

    [Header("Fly Settings")]
    public AirplaneConfig config;

    [Header("Missiles Settings")]
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform[] missilePos;

    [Header("Death Settings")]
    [SerializeField] private EndGame gameManager;

    [Header("Infos display")]
    [SerializeField] private Vector3 currentVelocity = Vector3.zero;


    private float turn;
    private Rigidbody rb;
    private Vector3 velocity = Vector3.zero;
    private bool ceilingExceed = false;
    private float timeSinceCeilingExceed = 0;
    private float delayCeiling = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isStarted)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            if (forwardControl) // Alternative - no rotation (edit global pos)
            {
                Vector3 direction = new Vector3(horizontalInput, verticalInput, 1);
                transform.position += direction * config.flySpeed;

            }
            else // with rotation (edit local pos)
            {
                // rigidbody velocity
                rb.velocity = transform.forward * config.flySpeed;
                
                
                // airplane rotations

                if (canTurn)
                {
                    turn += horizontalInput * config.degreeTurn * Time.deltaTime;
                    float pitch = Mathf.Lerp(0, config.degreePitch, Mathf.Abs(verticalInput)) * -Mathf.Sign(verticalInput);
                    float roll = Mathf.Lerp(0, config.degreeRoll, Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput);

                    transform.localRotation = Quaternion.Lerp(
                        transform.localRotation, 
                        Quaternion.Euler(Vector3.up * turn + Vector3.right * pitch + Vector3.forward * roll), 
                        Time.deltaTime * config.rotationLerpSpeed);
                }

                // ceiling delay management

                if (ceilingExceed)
                {
                    timeSinceCeilingExceed += Time.deltaTime;
                }
                if (timeSinceCeilingExceed > delayCeiling)
                {
                    ceilingExceed = false;
                }
            }
        }
    }

    // Rocket launcher
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ceiling") && !ceilingExceed && transform.rotation.x < 0)
        {
            ceilingExceed = true;
            timeSinceCeilingExceed = 0;
            Debug.Log("Ceiling exceed");

            foreach (Transform item in missilePos)
            {
                Instantiate(missilePrefab, item.position, item.rotation);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            Debug.Log("Game Over - Crash on the ground");
            gameManager.Die(gameObject);
        }

        if (collision.gameObject.CompareTag("obstacle"))
        {
            Debug.Log("Game Over - Crash on a obstacle");
            gameManager.Die(gameObject);
        }

        if (collision.gameObject.CompareTag("rocket"))
        {
            Debug.Log("Game Over - shot down by a missile");
            gameManager.Die(gameObject);
        }
    }
}
