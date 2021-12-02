using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Grenadine : Drink
{

    public static string NAME = "Grenadine";
    private static Color COLOR = new Color(0.878f, 0.082f, 0f, 1f);
    void Start()
    {
        this.setID(NAME);
        this.setColor(COLOR);
    }
}