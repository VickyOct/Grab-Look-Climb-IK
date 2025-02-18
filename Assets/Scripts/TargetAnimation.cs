using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAnimation : MonoBehaviour
{
    public Vector3 Dir;
    public Vector3 Start;

    private void Awake()
    {
        Start = transform.position;
    }

    void Update()
    {
        //just move the object from a to b and back
        transform.position = Start + Dir * Mathf.Sin(Time.timeSinceLevelLoad);
    }
}
