using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameUIManger : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;

    private void OnEnable()
    {
        EventManager.GameWin += WinPanel;
        EventManager.GameLose += LosePanel;
    }

    private void OnDisable()
    {
        EventManager.GameWin -= WinPanel;
        EventManager.GameLose -= LosePanel;
    }


    private void WinPanel()
    {
        _winPanel.SetActive(true);
    }
    
    private void LosePanel()
    {
        _losePanel.SetActive(true);
    }
}