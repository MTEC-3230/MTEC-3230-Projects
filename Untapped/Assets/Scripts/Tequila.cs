using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tequila : Drink
{

    public static string NAME = "Tequila";
    private static Color COLOR = new Color(1f, 1f, 1f, 0.3f);
    void Start()
    {
        this.setID(NAME);
        this.setColor(COLOR);
    }
}
