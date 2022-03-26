using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SandwichMerge.CurrentSlotValue = 0;
    }
    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex < 7)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(Random.Range(0, 7));
        }
        SandwichMerge.CurrentSlotValue = 0;
    }
}
