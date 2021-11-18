using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Screwdriver : Drink
{
    
    public static string NAME = "Screwdriver";
    private static Color COLOR = new Color(1f, 0.6f, 0.4f, 0.8f);
    
    void Start()
    {
        components = new List<Drink> {new OrangeJuice(), new Vodka()};
        this.setID(NAME);
        this.setColor(COLOR);
    }

    public override Drink Mix()
    {
        throw new System.NotImplementedException();
    }
}