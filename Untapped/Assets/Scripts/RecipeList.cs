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
    
    public Drink PourRecipe(GameObject bottle, Drink drink1, Drink drink2, Drink drink3)
    {
        return null;
    }
    
    /*public delegate void
     
    */

    public void Pour(GameObject a, GameObject b)
    {
        Mixer mixer1 = a.GetComponent<Mixer>();
        Mixer mixer2 = b.GetComponent<Mixer>();

        if (mixer1 == null || mixer2 == null)
        {
            Debug.Log("Something went wrong");
            return;
        }
        
        mixer2.mixerList.Add(mixer1.mixerList[0]);
        Drink newDrink = PourRecipe(b.gameObject, mixer2.mixerList[0], mixer2.mixerList[1]);
        if (newDrink != null)
        {
            mixer2.mixerList.Clear();
            mixer2.mixerList.Add(newDrink);
            mixer2.ID = mixer2.mixerList[0].getID();
            mixer2.color1 = (mixer2.mixerList[0].getColor());
        }
    }
    
}
