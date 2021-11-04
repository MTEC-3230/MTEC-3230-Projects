using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeList : MonoBehaviour
{
    public string ID = "Recipe Manager";
    
    // Start is called before the first frame update

    public Drink PourRecipe(GameObject bottle, Drink drink1, Drink drink2)
    {
        if (drink1.ID.Equals(Vodka.NAME) && drink2.ID.Equals(OrangeJuice.NAME))
        {
            return bottle.AddComponent<Screwdriver>();
        }

        return null;
    }
    
    /*public delegate void
     
    */
}
