using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AirplaneConfig", menuName = "My Game/New airplane config")]
public class AirplaneConfig : ScriptableObject
{
    public float flySpeed = 10f;
    public float yawAmount = 30f;
    public float pitchDegree = 60f;
    public float rollDegree = 30f;
}
