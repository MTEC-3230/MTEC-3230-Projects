using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class OrangeJuice : Drink
{

    public static string NAME = "Orange Juice";
    private static Color COLOR = new Color(1f, 0.6f, 0f, 1f);
    void Start()
    {
        this.setID(NAME);
        this.setColor(COLOR);
    }

    public override Drink Mix()
    {
        Glass thisGlass = this.gameObject.GetComponent<Glass>();
        for (int i = 0; i < thisGlass.mixerList.Count; i++)
        {
            if (thisGlass.mixerList[i].getID().Equals("Vodka"))
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