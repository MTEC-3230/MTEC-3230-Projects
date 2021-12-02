using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CranberryJuice : Drink
{
    public static string NAME = "Cranberry Juice";
    private static Color COLOR = new Color(1f, 0.301f, 0.364f, 1f);
    void Start()
    {
        this.setID(NAME);
        this.setColor(COLOR);
    }
}
