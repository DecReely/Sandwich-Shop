using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(0,10*Time.deltaTime,0);
    }
}
