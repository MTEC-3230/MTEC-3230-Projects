using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RedBull : Drink
{

    public static string NAME = "Redbull";
    private static Color COLOR = new Color(1f, 0.3f, 0.3f, 1f);
    void Start()
    {
        this.setID(NAME);
        this.setColor(COLOR);
    }
    
}