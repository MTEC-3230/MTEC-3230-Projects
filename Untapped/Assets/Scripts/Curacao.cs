using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curacao : Drink
{

    public static string NAME = "Curacao";
    private static Color COLOR = new Color(0.180f, 0.886f, 1f, 1f);
    void Start()
    {
        this.setID(NAME);
        this.setColor(COLOR);
    }
}
