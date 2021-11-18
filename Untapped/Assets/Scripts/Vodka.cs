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
}