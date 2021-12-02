using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Gin : Drink
{

    public static string NAME = "Gin";
    private static Color COLOR = new Color(1f, 1f, 1f, 0.2f);
    void Start()
    {
        this.setID(NAME);
        this.setColor(COLOR);
    }
}