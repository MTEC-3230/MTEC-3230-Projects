using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineappleJuice : Drink
{
    public static string NAME = "Pineapple Juice";
    private static Color COLOR = new Color(1f, 0.952f, 0.278f, 1f);
    void Start()
    {
        this.setID(NAME);
        this.setColor(COLOR);
    }
}
