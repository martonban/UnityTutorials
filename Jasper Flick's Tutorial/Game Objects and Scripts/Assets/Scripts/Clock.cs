using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] Transform hourPivot, minutePivot, secondPivot;

    private const float hoursToDegree = -30.0f, minutesToDegrees = -6f, secondsToDegrees = -6f;
    
    void Update()
    {
        DateTime time = DateTime.Now;
        hourPivot.localRotation = Quaternion.Euler(0.0f, 0.0f, hoursToDegree * time.Hour);
        minutePivot.localRotation = Quaternion.Euler(0f, 0f, minutesToDegrees * time.Minute);
        secondPivot.localRotation = Quaternion.Euler(0f, 0f, secondsToDegrees * time.Second);
    }
}
