using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleAnimation : MonoBehaviour
{
    public float amplitude = 10f; 
    public float frequency = 1f; 
    private Quaternion startRotation;

    private void Awake()
    {
        startRotation = transform.rotation;
    }

    void Update()
    {
        float angle = Mathf.Sin(Time.timeSinceLevelLoad * frequency) * amplitude;

        Quaternion rotation = Quaternion.Euler(0f, 0f, angle);

        transform.rotation = startRotation * rotation;
    }
}

