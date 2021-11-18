using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Glass : MonoBehaviour
{

    public string ID;
    public Color color1;
    
    //list of current drinks in the glass
    public List<Drink> currentDrinks = new List<Drink>();
    public Drink currentMixedDrink;
    
    //if it has at least one drink in it- this becomes the current recipes involving that drink?
    private Transform Liquid;
    private Renderer thisRenderer;

    // Start is called before the first frame update
    void Start()
    {
        Liquid = this.gameObject.transform.Find("Liquid");
        thisRenderer = Liquid.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDrinks.Count == 0)
        {
            this.ID = Drink.EMPTYNAME;
            this.color1 = Drink.EMPTYCOLOR;
        }
        else if (currentDrinks.Count == 1)
        {
            this.ID = currentDrinks[0].ID;
            this.color1 = currentDrinks[0].getColor();
        }
        else 
        {
            Drink newDrink = CheckForRecipe();
            if (newDrink != null)
            {
                addRecipe(newDrink);
            }
        }
        MixColor();
        thisRenderer.material.color = color1;
    }

    public void AddDrink(Drink d)
    {
        this.currentDrinks.Add(d);
    }
    
    public void RemoveDrink(Drink d)
    {
        this.currentDrinks.Remove(d);
    }

    private void MixColor()
    {
        if (currentMixedDrink != null)
        {
            this.color1 = currentMixedDrink.getColor();
        }
        else
        {
            Color newColor = new Color(0, 0, 0, 0);
            foreach (Drink d in this.currentDrinks)
            {
                newColor += d.getColor();
            }

            this.color1 = newColor;
        }
    }

    private Drink CheckForRecipe()
    {
        //Check all recipes in the dictionary
        foreach (KeyValuePair<string, Drink> k in BarManager.Instance.MasterRecipeList)
        {
            bool hasRecipeContents = true;
            foreach (Drink d in k.Value.components)
            {
                bool hasComponent = false;
                foreach (Drink d2 in currentDrinks)
                {
                    if (d2.getID().Equals(d.getID()))
                    {
                        hasComponent = true;
                    }
                }
                if (!hasComponent)
                {
                    hasRecipeContents = false;
                    break;
                }
            }
            if (hasRecipeContents)
            {
                return k.Value;
            }
        }
        return null;
    }

    private void addRecipe(Drink d)
    {
        currentMixedDrink = d;
    }

}
