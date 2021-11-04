using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Mixer : MonoBehaviour
{

    public string ID;
    public Color color1;
    private RecipeList recipes;
    
    public List<Drink> mixerList = new List<Drink>();
    
    private Renderer thisRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        thisRenderer = this.GetComponent<Renderer>();
        recipes = GameObject.Find("RecipeManager").GetComponent<RecipeList>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mixerList.Count == 1)
        {
            this.ID = (mixerList[0].getID());
            this.color1 = (mixerList[0].getColor());
        }
        else
        {
            Drink newDrink = recipes.PourRecipe(this.gameObject, mixerList[0], mixerList[1]);
            if (newDrink != null)
            {
                mixerList.Clear();
                mixerList.Add(newDrink);
                this.ID = mixerList[0].getID();
                this.color1 = (mixerList[0].getColor());
            }
        }
        
        if (thisRenderer != null)
        {
            thisRenderer.material.color = color1;
        }
    }
}
