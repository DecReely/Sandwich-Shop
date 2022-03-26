using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipe")]
public class Recipe : ScriptableObject
{
    public enum Ingredient
    {
        Empty,
        Cheese,
        Tomato,
        Cucumber,
        Pepper,
        Bacon
    }

    public enum CustomerName
    {
        Joe,
        Tyler,
        Annie,
        Lee,
        Clementine,
        Henry,
        Tony,
        Jean,
        Alex
    }

    public CustomerName customerName;
    
    //Buraya unity editor içerisinde bir ayırıcı koy, menü başlığı olabilir.

    public Ingredient[] sandwichLayers = new Ingredient[9];
}
