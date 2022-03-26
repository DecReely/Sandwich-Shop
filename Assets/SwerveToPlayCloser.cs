using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveToPlayCloser : MonoBehaviour
{
    [SerializeField] private GameObject _swerveToPlayText;
    
    private bool _pressed = false;
    private void Update()
    {
        if (Input.anyKey)
        {
            _pressed = true;
        }
        if (_pressed)
        {
            _swerveToPlayText.SetActive(false);
        }
    }

    

}
