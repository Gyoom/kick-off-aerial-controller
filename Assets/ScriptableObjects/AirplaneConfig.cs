using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AirplaneConfig", menuName = "My Game/New airplane config")]
public class AirplaneConfig : ScriptableObject
{
    public float flySpeed = 10f;
    public float rotationLerpSpeed = 10f;
    public float degreeTurn = 30f;
    public float degreePitch = 60f;
    public float degreeRoll = 30f;
}
