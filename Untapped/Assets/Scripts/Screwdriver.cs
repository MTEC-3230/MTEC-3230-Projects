using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Screwdriver : Drink
{

    private static string NAME = "Screwdriver";
    private static Color COLOR = new Color(1f, 0f, 0f, 1f);
    void Start()
    {
        this.setID(NAME);
        this.setColor(COLOR);
    }

}