using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Rum : Drink
{

    public static string NAME = "Rum";
    private static Color COLOR = new Color(0.705f, 0.596f, 0.415f, 1f);
    void Start()
    {
        this.setID(NAME);
        this.setColor(COLOR);
    }
}
