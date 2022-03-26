using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    [SerializeField] private Recipe recipe;
    [SerializeField] private GameObject breadSlice;

    private int _correctIngredientNumber;
    private int i;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bread"))
        {
            for (i = 0; i < SandwichMerge.CurrentSlotValue; i++)
            {
                if (other.gameObject.transform.GetChild(i).GetChild(0).CompareTag(recipe.sandwichLayers[i].ToString()))
                {
                    Debug.Log("Doğru malzeme: " + recipe.sandwichLayers[i]);
                    _correctIngredientNumber++;
                }
                else
                {
                    Debug.Log("Yanlış malzeme: " + recipe.sandwichLayers[i]);
                }
            }

            Instantiate(breadSlice, FindObjectOfType<SandwichMerge>().transform.GetChild(i).transform);

            if (_correctIngredientNumber >= (i / 3) + 1)
            {
                FindObjectOfType<GameManager>().Won();
                EventManager.GameWin?.Invoke();
            }
            else
            {
                FindObjectOfType<GameManager>().Failed();
                EventManager.GameLose?.Invoke();
            }
        }
    }
}
