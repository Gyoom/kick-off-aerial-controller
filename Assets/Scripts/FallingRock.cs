using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class FallingRock : MonoBehaviour
{
    public float fallingDistance;
    public Vector2 baseDirectionXZ;
    
    [SerializeField] private Vector2Int minMaxBounces;
    [SerializeField] private float fallingHeight;
    [SerializeField] private float bouncePower;
    [SerializeField] private float fallDuration;
    [SerializeField] private Ease fallCurve;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private ParticleSystem impactVFX;
    
    // Start is called before the first frame update
    void Start()
    {
        var positionDir = transform.position + new Vector3(baseDirectionXZ.x * fallingDistance, 0, baseDirectionXZ.y * fallingDistance);
        var endPosition = positionDir - new Vector3(0, fallingHeight, 0);

        transform.DOJump(endPosition, bouncePower, Random.Range(minMaxBounces.x, minMaxBounces.y + 1), fallDuration).SetEase(fallCurve).OnComplete(
            () =>
            {
                transform.DOScale(Vector3.zero, 0.2f);
                Instantiate(impactVFX, endPosition, Quaternion.identity);
            });
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0,0,1) * Time.deltaTime * rotationSpeed);
    }
}
