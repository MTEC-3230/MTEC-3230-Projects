using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Mixer : MonoBehaviour
{

    public string ID;
    public Color color1;
    
    public List<Drink> mixerList = new List<Drink>();
    
    private Renderer thisRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        thisRenderer = this.GetComponent<Renderer>();
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
            Drink newDrink = evaluateDrinkMix();
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

    Drink evaluateDrinkMix()
    {
        if (containsVodka() && containsOJ())
        {
            Screwdriver sc = gameObject.AddComponent(typeof(Screwdriver)) as Screwdriver;
            return sc;
        }
        else
        {
            return null;
        }
    }

    bool containsVodka()
    {
        foreach (Drink d in mixerList)
        {
            if (d is Vodka)
            {
                return true; 
            }
        }

        return false;
    }
    
    bool containsOJ()
    {
        foreach (Drink d in mixerList)
        {
            if (d is OrangeJuice)
            {
                return true; 
            }
        }

        return false;
    }
}
