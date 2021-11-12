using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Recipe currentRecipe;
    public DrinkContainer currentDrink;


    private void Update()
    {
        // Test whether Drink Container contains the same elements as current Recipe

        int num_contained_ingredients = 0;
        foreach (var drink in currentRecipe.ingredients)
        {
            
            if(currentDrink.contents.Contains(drink))
            {

                num_contained_ingredients++; 
            }
        }

        if(num_contained_ingredients == currentRecipe.ingredients.Count)
        {
            // You made a Drink!!!

        }
    }
}
