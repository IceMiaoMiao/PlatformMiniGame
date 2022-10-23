using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawRotation : MonoBehaviour
{
    public Vector3 rawRotation = new Vector3(0, 0, 2);
    
    private void FixedUpdate()
    {
        this.transform.Rotate(rawRotation);
    }
}
