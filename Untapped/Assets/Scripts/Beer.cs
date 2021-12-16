using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beer : Drink
{

    public static string NAME = "Beer";
    private static Color COLOR = new Color(0.447f, 0.262f, 0.133f, 1.0f);
    void Start()
    {
        this.setID(NAME);
        this.setColor(COLOR);
    }
}
