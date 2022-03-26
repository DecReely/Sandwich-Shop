using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void Failed()
    {
        Debug.Log("Game failed.");
    }
    
    public void Won()
    {
        Debug.Log("Game won.");
    }
}
