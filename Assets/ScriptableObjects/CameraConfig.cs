using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraConfig", menuName = "My Game/New camera config")]
public class CameraConfig : ScriptableObject
{
    public float verticalOffset = 4f;
    public float horizontalOffset = 10f;
    public float lag = 5f;
}
