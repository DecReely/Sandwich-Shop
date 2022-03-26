using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// https://www.youtube.com/watch?v=5UoVJPEAZRE
/// </summary>
public class SandwichMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigidBody;

    [SerializeField] 
    private Camera mainCamera;
    
    private const float ForceConstant = 4f;
    private const float TorqueConstant = 8f;
    
    private Vector2 _startSwipePosition;
    private Vector2 _stopSwipePosition;

    private Vector2 _swipeVector;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startSwipePosition = mainCamera.ScreenToViewportPoint(Input.mousePosition);
        }

        else if (Input.GetMouseButtonUp(0))
        {
            _stopSwipePosition = mainCamera.ScreenToViewportPoint(Input.mousePosition);
            Swipe();
        }
    }

    private void Swipe()
    {
        _swipeVector = _stopSwipePosition - _startSwipePosition;
        
        rigidBody.AddForce(_swipeVector*ForceConstant, ForceMode.Impulse);
        if (_swipeVector.x > 0)
        {
            rigidBody.AddTorque(0,0, -TorqueConstant, ForceMode.Impulse);
        }
        else
        {
            rigidBody.AddTorque(0,0, TorqueConstant, ForceMode.Impulse);
        }
    }
}