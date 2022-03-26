using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    
    private float _smoothSpeed = 4f; //Property'e dönüştürülecek.
    private Vector3 _offset = new Vector3(-1f,0.4f, -0.9f); //Property'e dönüştürülecek.
    private Vector3 _desiredPosition;
    private Vector3 _smoothedPosition;

    private void FixedUpdate()
    {
        _desiredPosition = target.position + _offset;
        _smoothedPosition = Vector3.Lerp(transform.position, _desiredPosition, _smoothSpeed*Time.deltaTime);
        transform.position = _smoothedPosition;
        
        transform.LookAt(target);
    }
}
