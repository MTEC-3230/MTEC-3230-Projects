using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Vodka : Drink
{

    public static string NAME = "Vodka";
    private static Color COLOR = new Color(1f, 1f, 1f, 0.6f);
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
            if (thisGlass.mixerList[i].getID().Equals("Orange Juice"))
            {
                return thisGlass.gameObject.AddComponent<Screwdriver>();
            }
        }

        return null;
    }
}