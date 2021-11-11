using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeList : MonoBehaviour
{
    public string ID = "Recipe Manager";
    
    // Start is called before the first frame update

    public void Start()
    {
        Pour.OnPour += aPour;
    }

    public Drink PourRecipe(GameObject bottle)
    {
        Glass mix = bottle.GetComponent<Glass>();
        if (mix == null)
        {
            Debug.Log("Something went wrong");
            return null;
        }

        Drink newDrink;

        for (int i = 0; i < mix.mixerList.Count; i++)
        {
            newDrink = mix.mixerList[i].Mix();
            if (newDrink != null)
            {
                Debug.Log(newDrink.getID());
                return newDrink;
            }
        }
        return null;
    }

    public void aPour(GameObject a, GameObject b)
    {
        Glass pourFrom = a.GetComponent<Glass>();
        Glass pourInto = b.GetComponent<Glass>();

        if (pourFrom == null || pourInto == null)
        {
            Debug.Log("Something went wrong");
            return;
        }

        bool doNotAdd = false;
        for (int i = 0; i < pourInto.mixerList.Count; i++)
        {
            if (pourInto.mixerList[i].name.Equals(pourFrom.mixerList[0].name))
            {
                doNotAdd = true;
            }
        }
        if (!doNotAdd)
        {
            pourInto.mixerList.Add(pourFrom.mixerList[0]);
        }

        Drink newDrink = PourRecipe(b.gameObject);
        if (newDrink != null)
        {
            pourInto.mixerList.Clear();
            pourInto.mixerList.Add(newDrink);
            pourInto.ID = pourInto.mixerList[0].getID();
            pourInto.color1 = (pourInto.mixerList[0].getColor());
        }
    }
}
