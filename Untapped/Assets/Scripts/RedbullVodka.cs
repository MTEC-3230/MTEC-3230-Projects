using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RedBullVodka : Drink
{

    public static string NAME = "Redbull Vodka";
    private static Color COLOR = new Color(1f, 0.3f, 0.4f, 0.8f);
    void Start()
    {
        this.setID(NAME);
        this.setColor(COLOR);
    }
    
    public override Drink Mix()
    {
        throw new System.NotImplementedException();
    }
}