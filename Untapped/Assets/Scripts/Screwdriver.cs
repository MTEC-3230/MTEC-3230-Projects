using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Screwdriver : Drink
{

    public static string NAME = "Screwdriver";
    private static Color COLOR = new Color(1f, 0.6f, 0f, 0.8f);
    void Start()
    {
        this.setID(NAME);
        this.setColor(COLOR);
    }

}