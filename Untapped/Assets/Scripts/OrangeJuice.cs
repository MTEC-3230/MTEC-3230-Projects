using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class OrangeJuice : Drink
{
    public static int value = 1;
    public static string NAME = "Orange Juice";
    private static Color COLOR = new Color(1f, 0.6f, 0f, 1f);
    private Glass thisGlass;
    void Start()
    {
        this.setID(NAME);
        this.setColor(COLOR);
        thisGlass = this.gameObject.GetComponent<Glass>();
    }

    public override Drink Mix()
    {
        for (int i = 0; i < thisGlass.currentDrinks.Count; i++)
        {
            if (thisGlass.currentDrinks[i].getID().Equals("Vodka"))
            {
                return thisGlass.gameObject.AddComponent<Screwdriver>();
            }
            /*
            if (thisGlass.mixerList[i].getID().Equals("Tequila"))
            {
                return thisGlass.gameObject.AddComponent<TequilaSunrise>();
            }*/
        }

        return null;
    }
}