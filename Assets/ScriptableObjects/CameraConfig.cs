using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraConfig", menuName = "My Game/New camera config")]
public class CameraConfig : ScriptableObject
{
    public float timeOffset = 0.05f;
    public Vector3 posOffset = new Vector3(0f, 4f, -10f);
}
